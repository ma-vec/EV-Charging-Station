using EV_Charging_Station;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace EV_Charging_Station;
public partial class Form1 : Form
{
    int freeStations = 0;
    int CarCounter = 0; // Contatore per identificare un'auto
    int StationCounter = 0; // Contatore per identificare una colonnina
    int PowerForProgressBar;
    int tempP; //valore potenza massima di partenza
    SemaphoreSlim stationSemaphore = new SemaphoreSlim(0); // Gestione concorrenza

    List<Station> AllStations = new List<Station>();
    List<Car> AllCars = new List<Car>();

    private Label[] labelsStation = new Label[100]; //Array per label Stazioni
    private ProgressBar[] barStation = new ProgressBar[100]; //Array per progress bar Stazioni

    public Form1()
    {
        InitializeComponent();
    }

    private void ThreadAuto(object autoObj)
    {
        if (autoObj == null)
        {
            this.Invoke((MethodInvoker)delegate //delegate assegna le operazioni UI a thread principale
            {
                MessageBox.Show("Errore: oggetto auto nullo.");
            });
            return;
        }

        Car auto = (Car)autoObj; //riconverte un obj (necessario per la funzione) in Car

        Station assignedStation = null;
        try
        {
            // Attende una colonnina libera
            stationSemaphore.Wait();

            
            lock (AllStations)
            {
                // Trova una colonnina libera
                assignedStation = AllStations.Find(station => station.IsFree);
                if (assignedStation != null)
                {
                    assignedStation.GivePower(auto);
                    //MessageBox.Show("colonnina assegnata");
                }
            }

            if (assignedStation != null)
            {

                this.Invoke((MethodInvoker)delegate
                {
                    UpdateForm();
                    MessageBox.Show($"Auto {auto.Id} ({auto.Soc}%) è collegata alla colonnina {assignedStation.Type}{assignedStation.Id.ToString()}");
                });
                // Simula il processo di ricarica
                PowerForProgressBar = assignedStation.PowerMax;
                tempP = assignedStation.PowerMax; //salva la potenza di "base", poi modificata in base a BMS
                double coeffDiminuzione; //regola la curva di ricarica in base al tipo di colonnina

                if (tempP < 40)
                {
                    coeffDiminuzione = 1;
                }
                else if (tempP < 100)
                {
                    coeffDiminuzione = 0.9;
                }
                else
                {
                    coeffDiminuzione = 0.85;
                }
                do
                {

                    if (auto.Soc >= 80 && auto.Soc < 95)
                    {
                        coeffDiminuzione -= 0.05; //simula la curva di ricarica
                        assignedStation.PowerMax = (int)(tempP * coeffDiminuzione);
                        PowerForProgressBar = assignedStation.PowerMax;

                    }
                    int timeForPerc = (int)((1) / ((double)assignedStation.PowerMax / 10000)); //nel do per cambiare power (BMS)

                    Thread.Sleep(timeForPerc);
                    auto.Soc += 1;
                    auto.UpdateSoC();
                    UpdateLabelStation(assignedStation);
                    UpdateForm();
                } while (auto.Soc != 100);

                assignedStation.StopPower(auto);
                assignedStation.PowerMax = tempP; //riporta la stazione alla potenza definita

                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Auto {auto.Id} ha terminato la ricarica dalla colonnina {assignedStation.Type}{assignedStation.Id.ToString()}");
                });
            }
        }
        catch (Exception ex)
        {
            // Gestione di eccezioni non previste
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show($"Errore nel thread Auto {auto.Id}: {ex.Message}");
            });
        }
        finally
        {
            // Libera una colonnina
            if (stationSemaphore != null)
            {
                stationSemaphore.Release(); //semaphore rilascia la risorsa colonnina al termine
            }
            UpdateLabelStation(assignedStation);
            UpdateForm();
        }
    }


    private void UpdateForm()
    {


        lock (AllStations)
        {
            freeStations = AllStations.FindAll(station => station.IsFree).Count; //conta le stazioni libere
        }

        this.Invoke((MethodInvoker)delegate //gestione UI
        {
            labelFreeStationNumber.Text = freeStations.ToString();
            listBoxStation.DataSource = null;
            listBoxStation.DataSource = AllStations;
            listBoxStation.DisplayMember = "stringForUI";
            listBoxCars.DataSource = null;
            listBoxCars.DataSource = AllCars;
            listBoxCars.DisplayMember = "cstringForUI";
            
        });
        
    }

    private void buttonAddCar_Click(object sender, EventArgs e)
    {
        if (AllStations.Count == 0)
        {
            MessageBox.Show("Non ci sono colonnine in questo parcheggio", "Errore");
            return;
        }

        CarCounter++;
        Car car = new Car(CarCounter);
        car.Soc = Convert.ToInt32(numericSoC.Value);
        lock (AllCars)
        {
            AllCars.Insert(0, car); // Aggiorna la lista

        }

        car.StopCharging(); //garantisce che l'auto sia inizializzata come non in carica
        Thread threadCar = new Thread(() => ThreadAuto(car));
        threadCar.Start();
        
        UpdateForm();
    }

    private void buttonAddStation_Click(object sender, EventArgs e)
    {
        if (freeStations == StationCounter)
        {
            int power = 0;
            string typeStation = null;
            switch (comboBoxStation.SelectedIndex)
            {
                case 0: power = 22; typeStation = "Q"; break;
                case 1: power = 50; typeStation = "F"; break;
                case 2: power = 150; typeStation = "H"; break;
                default: MessageBox.Show("Seleziona una potenza dall'elenco a discesa", "Errore"); break;
            }
            if (power != 0)
            {
                StationCounter++;
                Station station = new Station(typeStation, StationCounter, power);
                station.SetFree();

                this.Invoke((MethodInvoker)delegate
                {
                    int baseY = 70 + (80 * (StationCounter - 1)); // Aumenta l'offset verticale tra i gruppi

                    // Label
                    labelsStation[StationCounter - 1] = new Label();
                    labelsStation[StationCounter - 1].Location = new Point(37, baseY); // Posizione relativa al gruppo
                    labelsStation[StationCounter - 1].Size = new Size(120, 30);

                    this.Controls.Add(labelsStation[StationCounter - 1]);

                    // Progress Bar
                    barStation[StationCounter - 1] = new ProgressBar();
                    barStation[StationCounter - 1].Location = new Point(37, baseY + 40); // Offset interno tra label e progress bar
                    barStation[StationCounter - 1].Size = new Size(204, 23);
                    barStation[StationCounter - 1].Minimum = 0;
                    barStation[StationCounter - 1].Maximum = power;
                    this.Controls.Add(barStation[StationCounter - 1]);
                });


                lock (AllStations)
                {
                    AllStations.Add(station);
                }

                stationSemaphore.Release();
                UpdateLabelStation(station);
                UpdateForm();
            }
        }
        else
        {
            this.Invoke((MethodInvoker)delegate
            {//gestione UI
                MessageBox.Show("Attendi che tutte le stazioni siano libere per aggiungere una colonnina");
            });
        }
    }

    private void UpdateLabelStation(Station stazione)
    {
        if(stazione == null) return;
        if (stazione.IsFree)
        {
            this.Invoke((MethodInvoker)delegate
            {//gestione UI
                labelsStation[stazione.Id - 1].Text = $"{stazione.Type}{stazione.Id.ToString()} libera";
                barStation[stazione.Id - 1].Value = 0;
            });
        }
        else
        {
            this.Invoke((MethodInvoker)delegate
            { //gestione UI
                labelsStation[stazione.Id - 1].Text = $"{stazione.Type}{stazione.Id.ToString()} eroga {stazione.PowerMax.ToString()} kW";
                barStation[stazione.Id - 1].Value = stazione.PowerMax;
            });
        }
    }

}

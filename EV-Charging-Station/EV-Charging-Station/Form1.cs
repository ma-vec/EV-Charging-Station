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
    SemaphoreSlim stationSemaphore = new SemaphoreSlim(0); // Gestione concorrenza

    List<Station> AllStations = new List<Station>();
    List<Car> AllCars = new List<Car>();

    public Form1()
    {
        InitializeComponent();
    }

    private void ThreadAuto(object autoObj)
    {
        if (autoObj == null)
        {
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show("Errore: oggetto auto nullo.");
            });
            return;
        }

        Car auto = (Car)autoObj;

        try
        {
            //MessageBox.Show("In try");
            // Attende una colonnina libera
            stationSemaphore.Wait();

            Station assignedStation = null;
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
                    MessageBox.Show($"Auto {auto.Id} è collegata alla colonnina {assignedStation.SerialNumber}");
                });

                // Simula il processo di ricarica
                Thread.Sleep(10000); // Tempo di ricarica
                auto.Soc = 100;
                assignedStation.StopPower(auto);

                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Auto {auto.Id} ha terminato la ricarica dalla colonnina {assignedStation.SerialNumber}");
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
                stationSemaphore.Release();
            }
            UpdateForm();
        }
    }


    private void UpdateForm()
    {
        

        lock (AllStations)
        {
            freeStations = AllStations.FindAll(station => station.IsFree).Count;
        }

        this.Invoke((MethodInvoker)delegate
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
        lock (AllCars) {
            AllCars.Add(car);
        }
        car.StopCharging();
        MessageBox.Show($"Auto {car.Id} aggiunta.");
        Thread threadCar = new Thread(() => ThreadAuto(car));
        threadCar.Start();
        UpdateForm();
    }

    private void buttonAddStation_Click(object sender, EventArgs e)
    {
        StationCounter++;
        Station station = new Station($"S{StationCounter}");
        station.SetFree();

        lock (AllStations)
        {
            AllStations.Add(station);
        }

        /*if (stationSemaphore == null)
        {
            // Inizializza il semaforo con il numero attuale di colonnine
            stationSemaphore = new SemaphoreSlim(AllStations.Count, AllStations.Count);
        }
        else
        {
            // Aggiorna il limite massimo del semaforo
            int currentCount = stationSemaphore.CurrentCount;
            stationSemaphore = new SemaphoreSlim(currentCount, AllStations.Count);
        }*/
        stationSemaphore.Release();

        MessageBox.Show($"Colonnina {station.SerialNumber} aggiunta.");
        UpdateForm();
    }

}

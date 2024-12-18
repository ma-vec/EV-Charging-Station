using System.Diagnostics.Eventing.Reader;

namespace EV_Charging_Station
{
    public partial class Form1 : Form
    {
        int CarCounter = 0; //contatore per identificare un'auto
        int StationCounter = 0; //contatore per identificare una colonnina
        int StationFree = 0;
        List<Station> AllStations = new List<Station>();
        public Form1()
        {
            InitializeComponent();
        }

        private void ThreadAuto(object autoObj)
        {
            try
            {
                if (autoObj == null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("Errore: oggetto auto nullo.");
                    });
                    return;
                }

                // Script per collegare auto alla colonnina
                Car auto = (Car)autoObj;
                bool messaggioMostrato = false;

                while (!auto.IsCharging)
                {
                    if (StationFree > 0)
                    {
                        foreach (Station stat in AllStations)
                        {
                            if (stat.IsFree)
                            {
                                stat.GivePower(auto);
                                StationFree--;
                                this.Invoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show("Auto " + auto.Id + " è collegata alla colonnina " + stat.SerialNumber);
                                });
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (!messaggioMostrato)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("L'auto " + auto.Id.ToString() + " è in attesa", "Tutte le colonnine sono occupate");
                            });
                            messaggioMostrato = true;
                        }
                        Thread.Sleep(1000);
                    }
                }
                UpdateForm();
            }
            
            catch (Exception ex)
            {
                // Gestione eccezioni nel thread
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show("Errore nel thread: " + ex.Message);
                });
            }
        }


        private void UpdateForm()
        {
            StationFree = 0;
            StationCounter = AllStations.Count;
            foreach (Station stat in AllStations)
            {
                if (stat.IsFree)
                    StationFree++;
            }
            labelFreeStationNumber.Text = StationFree.ToString();
        }

        private void buttonAddCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (StationCounter == 0)
                {
                    MessageBox.Show("Non ci sono colonnine in questo parcheggio", "Errore");
                }
                else
                {
                    CarCounter++;
                    Car car = new Car(CarCounter);
                    object carObj = car;
                    MessageBox.Show("Auto " + car.Id);
                    // Richiama il metodo ThreadAuto
                    Thread threadCar = new Thread(() => ThreadAuto(carObj));
                    threadCar.Start();
                }
                UpdateForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore durante l'aggiunta dell'auto: " + ex.Message, "Errore");
            }
        }


        private void buttonAddStation_Click(object sender, EventArgs e)
        {
            Station station = new Station("S"+StationCounter.ToString());
            station.SetFree();
            AllStations.Add(station);
            MessageBox.Show(StationFree.ToString());
            UpdateForm();
        }
    }
}

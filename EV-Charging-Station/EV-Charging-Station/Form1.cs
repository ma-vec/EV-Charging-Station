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
            
            if(StationFree>0)
            {

            }
        }

        private void buttonAddStation_Click(object sender, EventArgs e)
        {
            Station station = new Station("S"+StationCounter.ToString());
            station.SetFree();
            AllStations.Add(station);
            UpdateForm();
        }
    }
}

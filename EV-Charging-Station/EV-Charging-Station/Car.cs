using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EV_Charging_Station
{
    internal class Car
    {
        private int id; //Assegnato progressivamente alle nuove auto
        public int Id { get { return id; } }

        private bool isInPark; //true se l'auto è entrata nel parcheggio
        public bool IsInPark { get { return IsInPark; } }

        private bool isCharging;
        public bool IsCharging { get { return isCharging; } }

        private string cstringForUI;
        public string CstringForUI { get { return cstringForUI; } }

        private int soc;
        public int Soc
        {
            get { return soc; }
            set
            {
                if (value < 0)
                    soc = 0;
                else if (value > 100)
                    soc = 100;
                else
                    soc = value;
            }
        }

        public void EnterInPark()
        {
            isInPark = true;
        }
        public void ExitToPark()
        {
            isInPark = false;
        }

        public void StartCharging()
        {
            isCharging = true;
            cstringForUI = id.ToString() + " collegata";
        }
        public void StopCharging()
        {
            isCharging = false;
            if (soc < 100)
            {
                cstringForUI = id.ToString() + " in attesa";
            } else
            {
                cstringForUI = id.ToString() + " terminato";
            }
        }

        public Car(int id)
        {
            this.id = id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV_Charging_Station
{
    internal class Station
    {
        private Car carInCharge; //Associazione di un'auto a una colonnina
        public Car CarInCharge
        {
            get { return carInCharge; }
            set { carInCharge = value; }
        }

        private string type;
        public string Type
        {
            get { return type; }
        }

        private int id;
        public int Id { get { return id; } }

        private int powerMax;
        public int PowerMax
        {
            get { return powerMax; }
            set
            {
                if (value < 20)
                    powerMax = 20;
                else if (value > 350)
                    powerMax = 350;
                else
                    powerMax = value;
            } //set necessario simulazione BMS
        }
        private bool isFree;
        public bool IsFree { get { return isFree; } }

        private string stringForUI; //necessario per utilizzo listbox (log)
        public string StringForUI { get { return stringForUI; } }

        public void GivePower(Car car)
        {
            if(car ==  null || car.IsCharging || car.Soc == 100)
                return;
            isFree = false;
            car.StartCharging();
            stringForUI = car.Id.ToString() + " in carica in " + type+id.ToString();
        }
        public void StopPower(Car car)
        {
            if (car == null || !car.IsCharging)
                return;
            SetFree();
            car.StopCharging();
        }
        public void SetFree()
        {
            isFree = true;
            stringForUI = type + id.ToString() + " libera";
        }


        public Station(string type, int id, int powerMax)
        {
            this.type = type;
            this.id = id;
            this.powerMax = powerMax;

        }
    }
}

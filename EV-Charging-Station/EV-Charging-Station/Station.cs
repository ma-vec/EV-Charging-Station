﻿using System;
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

        private string serialNumber;
        public string SerialNumber
        {
            get { return serialNumber; }
        }
        private int power;
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        private bool isFree;
        public bool IsFree { get { return isFree; } }

        public void GivePower(Car car)
        {
            if(car ==  null || !car.IsInPark || car.IsCharging || car.Soc == 100)
                return;
            power = 150;
            isFree = false;
            car.StartCharging();
        }
        public void StopPower(Car car)
        {
            if (car == null || !car.IsInPark || !car.IsCharging)
                return;
            power = 0;
            isFree = true;
            car.StopCharging();
            car.ExitToPark(); //una volta terminata la ricarica esce in automatico dal parcheggio
        }
        public void SetFree()
        {
            isFree = true;
        }

        public Station(string serialNumber)
        {
            this.serialNumber = serialNumber;
        }
    }
}

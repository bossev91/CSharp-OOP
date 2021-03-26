using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double ACModifier = 1.4;

        public Bus(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity, ACModifier)
        {
        }

        public void TurnOnAirConditioner()
        {
            this.AirConditionerMofifier = ACModifier;
        }

        public void ATurnOffAirConditioner()
        {
            this.AirConditionerMofifier = 0;
        }


       

    }
}

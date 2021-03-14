using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        
        protected Vehicle(double fuelQuantity, double fuelConsumption, double airConditionerModifier)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirConditionerModifier = airConditionerModifier;
           
        }
        private double AirConditionerModifier { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
    
        public virtual void Drive(double distance)
        {
            double fuelNeeded = (FuelConsumption + this.AirConditionerModifier) * distance;

            if(FuelQuantity >= fuelNeeded)
            {
                FuelQuantity -= fuelNeeded;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }

        }

        public virtual void Refuel(double refuel)
        {
            FuelQuantity += refuel;
        }
    }


}

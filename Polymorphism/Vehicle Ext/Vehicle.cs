using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuel;

        protected Vehicle(double fuel, double fuelConsumption, double tankCapacity, double acModifier)
        {
            this.TankCapacity = tankCapacity;
            this.Fuel = fuel;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionerMofifier = acModifier;
            
        }

        protected double AirConditionerMofifier { get; set; }

        public double Fuel
        {
            get => this.fuel;
            set
            {
                if(value > this.TankCapacity)
                {
                    this.fuel = 0;
                }
                else
                {
                    this.fuel = value;
                }
                
            }
        }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

        public void Drive(double distance)
        {
            double requiredFuel = distance * (this.FuelConsumption + this.AirConditionerMofifier);

            if(this.Fuel < requiredFuel)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
            this.Fuel -= requiredFuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if(this.Fuel + amount > TankCapacity)
            {
               
                    Console.WriteLine($"Cannot fit {amount} fuel in the tank");
                
                
            }
            else
            {

            this.Fuel += amount;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Fuel:f2}";
        }

        
    }
}

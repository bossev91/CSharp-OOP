using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double DefaultAirConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption, DefaultAirConsumption)
        {
        }

        public override void Refuel(double refuel)
        {
            base.Refuel(refuel * 0.95);
        }
    }
}

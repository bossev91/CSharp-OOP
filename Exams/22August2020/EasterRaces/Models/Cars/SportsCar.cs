using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public class MuscleCar : Car
    {
        private const double defaultCubicCentimeters = 5000;
        private const int minHorsePower = 400;
        private const int maxHorsePower = 600;

        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, defaultCubicCentimeters, minHorsePower, maxHorsePower)
        {
        }
    }
}

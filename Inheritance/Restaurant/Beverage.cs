using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            Mililliters = milliliters;
        }

        public double Mililliters { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public class Cake : BakedFood
    {
        private const int defaultPortion = 200;

        public Cake(string name, decimal price)
            : base(name, defaultPortion, price)
        {
        }
    }
}

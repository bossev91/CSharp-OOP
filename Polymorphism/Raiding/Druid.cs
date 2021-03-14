using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int defaultPower = 80;

        public Druid(string name) 
            : base(name, defaultPower)
        {}

        public override string CastAbility()
        {
            return base.CastAbility();
        }

    }
}

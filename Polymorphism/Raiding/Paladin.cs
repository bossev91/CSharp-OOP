using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int defaultPower = 100;

        public Paladin(string name) 
            : base(name, defaultPower)
        {}

        public override string CastAbility()
        {
            return base.CastAbility();
        }

    }
}

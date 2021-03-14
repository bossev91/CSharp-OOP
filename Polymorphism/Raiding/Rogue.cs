using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int defaultPower = 80;

        public Rogue(string name)
            : base(name, defaultPower)
        { }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {defaultPower} damage";
        }
    }
}

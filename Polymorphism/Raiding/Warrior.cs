using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int defaultPower = 100;

        public Warrior(string name)
            : base(name, defaultPower)
        { }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {defaultPower} damage";
        }
    }
}

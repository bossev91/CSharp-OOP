using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {

            int dmg = 0;
            List<BaseHero> counter = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());

            while (true)
            {
                BaseHero currentHero = null;


                string name = Console.ReadLine();
                string typeOfHero = Console.ReadLine();

                if (typeOfHero == nameof(Druid))
                {
                    currentHero = new Druid(name);
                }
                else if (typeOfHero == nameof(Paladin))
                {
                    currentHero = new Paladin(name);
                }
                else if (typeOfHero == nameof(Rogue))
                {
                    currentHero = new Rogue(name);
                }
                else if (typeOfHero == nameof(Warrior))
                {
                    currentHero = new Warrior(name);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                

                Console.WriteLine(currentHero.CastAbility());
                dmg += currentHero.Power;

                if (currentHero != null)
                {
                    counter.Add(currentHero);
                    if (counter.Count == n)
                    {
                        break;
                    }
                }
            }

            int bossHealth = int.Parse(Console.ReadLine());

            if(dmg >= bossHealth)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
            
                
        }
    }
}

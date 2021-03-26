using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> list = new List<IBirthable>();

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "End")
                {
                    break;
                }

                string[] lineArg = command.Split();
                string type = lineArg[0];

                if(type == nameof(Citizen))
                {
                    string name = lineArg[1];
                    int age = int.Parse(lineArg[2]);
                    string id = lineArg[3];
                    string birthdate = lineArg[4];

                    list.Add(new Citizen(name, age, id, birthdate));
                }
                else if(type == nameof(Pet))
                {
                    string name = lineArg[1];
                    string birthdate = lineArg[2];

                    list.Add(new Pet(name, birthdate));
                }
            
            }

            string yearCheck = Console.ReadLine();

            var result = list.Where(x => x.Birthdate.EndsWith(yearCheck)).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item.Birthdate);
            }

            

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> list = new List<IIdentifiable>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] cmdArg = line.Split();

                if(cmdArg.Length == 3)
                {
                    string name = cmdArg[0];
                    int age = int.Parse(cmdArg[1]);
                    string id = cmdArg[2];

                    list.Add(new Citizen(name, age, id));
                }
                else
                {
                    string model = cmdArg[0];
                    string id = cmdArg[1];
                    list.Add(new Robot(model, id));
                }

            }
            string factory = Console.ReadLine();

            var result = list
                .Where(x => x.Id.EndsWith(factory))
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
            }

        }
    }
}

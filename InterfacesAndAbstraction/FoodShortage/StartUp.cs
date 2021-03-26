using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> collection = new Dictionary<string, IBuyer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                string name = line[0];
                int age = int.Parse(line[1]);

                if(line.Length == 4)
                {
                    string id = line[2];
                    string birthdate = line[3];
                    collection.Add(name, new Citizen(name, age, id, birthdate));
                }
                if(line.Length == 3)
                {
                    string group = line[2];
                    collection.Add(name, new Rebel(name, age, group));
                }
            }

            while(true)
            {
                string cmdArg = Console.ReadLine();
                if(cmdArg == "End")
                {
                    break;
                }
                else
                {
                    if(collection.ContainsKey(cmdArg))
                    {
                        collection[cmdArg].BuyFood();
                    }
                }
            }
            int result = 0;

            foreach (var item in collection)
            {
                result += item.Value.Food;
            }

            Console.WriteLine(result);
        }
    }
}

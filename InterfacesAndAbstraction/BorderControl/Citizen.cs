using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable 
    {
        public Citizen(string name, int age, string id )
        {
            Name = name;
            Age = age;
            Id = id;
            //Birthdate = birthdate;

        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        //public string Birthdate { get; private set; }
    }
}

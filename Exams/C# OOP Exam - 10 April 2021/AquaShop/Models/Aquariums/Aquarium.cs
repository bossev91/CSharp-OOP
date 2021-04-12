using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fish;


        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            set
            {
                this.capacity = value;
            }
        }

        public int Comfort
        {
            get
            {
                int result = 0;
                foreach (var item in decorations)
                {
                    result += item.Comfort;
                }

                return result;

            }
        }

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if(this.capacity <= this.fish.Count)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var item in this.fish)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            throw new NotImplementedException();
        }

        public bool RemoveFish(IFish fish)
        {
            if(this.fish.Contains(fish))   // TO CHECK !
            {
                this.fish.Remove(fish);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if(fish.Count == 0)
            {
                sb.AppendLine($"none");
            }
            else
            {
                string result = string.Join(", ", this.fish); // CHECK !!!
                sb.AppendLine(result);
            }
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();

            
            
        }
    }
}

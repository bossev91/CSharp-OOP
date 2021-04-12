using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class AquariumRepository : IRepository<IAquarium>
    {
        private List<IAquarium> aquarium;
        public AquariumRepository()
        {
            this.aquarium = new List<IAquarium>();
        }


        public IReadOnlyCollection<IAquarium> Models => this.aquarium;

        public void Add(IAquarium model)
        {
            this.aquarium.Add(model);
        }

        public IAquarium FindByType(string type)
        {
           return this.aquarium.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IAquarium model)
        {
            return this.aquarium.Remove(model);
        }
    }
}

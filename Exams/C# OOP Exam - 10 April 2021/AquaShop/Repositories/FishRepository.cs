using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private List<IFish> fish;
        public FishRepository()
        {
            fish = new List<IFish>();
        }

        public IReadOnlyCollection<IFish> Models => this.fish;

        public void Add(IFish model)
        {
            this.fish.Add(model);
        }

        public IFish FindByType(string type)
        {
            return this.fish.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IFish model)
        {
            return this.fish.Remove(model);
        }
    }
}

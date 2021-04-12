using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        public IRepository<IDecoration> decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();

        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            this.aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            this.decorations.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            bool canLive = true;

            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);

                if (aquarium.GetType().Name == "SaltwaterAquarium")
                {
                    canLive = false;
                }
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);

                if (aquarium.GetType().Name == "FreshwaterAquarium")
                {
                    canLive = false;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if (canLive == false)
            {
                return OutputMessages.UnsuitableWater;
            }
            else
            {
                aquarium.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            //var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            //IFish fish = null;
            //if (fishType == "FreshwaterFish")
            //{
            //    fish = new FreshwaterFish(fishName, fishSpecies, price);
            //}
            //else if (fishType == "SaltwaterFish")
            //{
            //    fish = new SaltwaterFish(fishName, fishSpecies, price);
            //}
            //else
            //{
            //    throw new InvalidOperationException("Invalid fish type.");
            //}

            //if (aquarium.GetType().Name == "FreshwaterAquarium" && fish.GetType().Name == "FreshwaterFish")
            //{
            //    aquarium.AddFish(fish);
            //    return $"Successfully added {fishType} to {aquariumName}.";
            //}
            //if (aquarium.GetType().Name == "SaltwaterAquarium" && fish.GetType().Name == "SaltwaterFish")
            //{
            //    aquarium.AddFish(fish);
            //    return $"Successfully added {fishType} to {aquariumName}.";
            //}
            //else
            //{
            //    return "Water not suitable.";
            //}



        }

        public string CalculateValue(string aquariumName)
        {

            decimal value = 0;
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            foreach (var item in aquarium.Decorations)
            {
                value += item.Price;
            }
            foreach(var item in aquarium.Fish)
            {
                value += item.Price;
            }
            return $"The value of Aquarium {aquariumName} is {value:f2}.";

            
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}

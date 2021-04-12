using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var car = carRepository.GetByName(carModel);
            var driver = driverRepository.GetByName(driverName);

            if(driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            if(car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);

            this.carRepository.Remove(car);
            
            return $"Driver {driverName} received car {carModel}.";
            
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = raceRepository.GetByName(raceName);
            var driver = driverRepository.GetByName(driverName);

            if(race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if(driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";

        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            if (carRepository.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            carRepository.Add(car);
            return $"{type} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            IDriver driverExist = driverRepository.GetByName(driverName);
            
            if (driverExist != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            var newDriver = new Driver(driverName);
            driverRepository.Add(newDriver);
            return $"Driver {driverName} is created.";   

        }

        public string CreateRace(string name, int laps)
        {
            var raceExist = raceRepository.GetByName(name);
            if(raceExist != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            var newRace = new Race(name, laps);
            raceRepository.Add(newRace);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if(race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var driversWin = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).ToList();
            StringBuilder sb = new StringBuilder();

            var first = driversWin[0];
            var second = driversWin[1];
            var third = driversWin[2];

            sb.AppendLine($"Driver {first.Name} wins {raceName} race.");
            sb.AppendLine($"Driver {second.Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {third.Name} is third in {raceName} race.");

            return sb.ToString().TrimEnd();


        }
    }
}


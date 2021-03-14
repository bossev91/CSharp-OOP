using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine().Split();
                string command = cmdArg[0];
                string type = cmdArg[1];
                double distance = double.Parse(cmdArg[2]);

                if(command == "Drive")
                {
                    if(type == typeof(Car).Name)
                    {
                        car.Drive(distance);
                    }
                    else
                    {
                        truck.Drive(distance);
                    }
                }
                else if (command == "Refuel")
                {
                    if(type == typeof(Car).Name)
                    {
                        car.Refuel(distance);
                    }
                    else
                    {
                        truck.Refuel(distance); 
                    }
                }

            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }

        private static Vehicle CreateVehicle()
        {
            Vehicle newVehicle = null;

            string[] cmdArg = Console.ReadLine().Split();
            string type = cmdArg[0];
            double fuel = double.Parse(cmdArg[1]);
            double consumption = double.Parse(cmdArg[2]);

            if(type == "Car")
            {
                newVehicle = new Car(fuel, consumption);
                return newVehicle;
            }
            if(type == "Truck")
            {
                newVehicle = new Truck(fuel, consumption);
                return newVehicle;
            }

            return null;
        }
    }
}

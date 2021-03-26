using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {

           

            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();
            int cmn = int.Parse(Console.ReadLine());

            //	"Vehicle {initial fuel quantity} {liters per km} {tank capacity}"

            


            for (int i = 0; i < cmn; i++)
            {
                var line = Console.ReadLine().Split();
                string command = line[0];
                string type = line[1];
                double parameter = double.Parse(line[2]);

                if(type == nameof(Car))
                {
                    MakeAction(car, command, parameter);
                }
                else if(type == nameof(Truck))
                {
                    MakeAction(truck, command, parameter);
                }
                else if(type == nameof(Bus))
                {
                    MakeAction(bus, command, parameter);
                }
                               
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);


            
        }

        private static void MakeAction(Vehicle vehicle, string command, double parameter)
        {
            try
            {
                if (command == "Drive")
                {
                    vehicle.Drive(parameter);
                }
                else if (command == "Refuel")
                {
                    vehicle.Refuel(parameter);
                }
                else if(command == "DriveEmpty")
                {
                    ((Bus)vehicle).ATurnOffAirConditioner();
                    vehicle.Drive(parameter);
                    ((Bus)vehicle).TurnOnAirConditioner();
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static Vehicle CreateVehicle()
        {
            Vehicle current = null;

            string[] input = Console.ReadLine().Split();
            string type = input[0];
            double fuel = double.Parse(input[1]);
            double consumption = double.Parse(input[2]);
            double tankCapacity = double.Parse(input[3]);

            if(type == nameof(Car))
            {
                current = new Car(fuel, consumption, tankCapacity);
            }
            if(type == "Truck")
            {
                current = new Truck(fuel, consumption, tankCapacity);
            }
            if(type == "Bus")
            {
                current = new Bus(fuel, consumption, tankCapacity);
            }

            return current;

        }
    }
}

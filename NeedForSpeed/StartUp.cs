namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RaceMotorcycle raceMotor = new RaceMotorcycle(200, 100);

            System.Console.WriteLine(raceMotor.FuelConsumption);

            Car car = new Car(200, 100);

            System.Console.WriteLine(car.FuelConsumption);

            Motorcycle motorcycle = new Motorcycle(200, 100);

            System.Console.WriteLine($"MotorCycle consuption = {motorcycle.FuelConsumption}");

            SportCar sportCar = new SportCar(200, 100);

            System.Console.WriteLine(sportCar.FuelConsumption);
        }
    }
}

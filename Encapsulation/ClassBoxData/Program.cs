using System;

namespace ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
           decimal length = decimal.Parse(Console.ReadLine());
           decimal width = decimal.Parse(Console.ReadLine());
           decimal height = decimal.Parse(Console.ReadLine());

            

            try
            {
                var box = new Box(length, width, height);


                Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.CalculateLeteralArea():f2}");
                Console.WriteLine($"Volume - {box.CalculateVolume():f2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}

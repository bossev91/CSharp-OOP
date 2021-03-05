namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Cake cake = new Cake("Space Cake");

            System.Console.WriteLine($"{cake.Name} - {cake.Grams} - {cake.Calories} - {cake.Price}");
        }
    }
}
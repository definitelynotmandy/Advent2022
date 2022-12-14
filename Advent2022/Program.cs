internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Pick a day: ");

            if (!int.TryParse(Console.ReadLine(), out var day))
            {
                Console.WriteLine("Enter a day in numeric value.\n");
                continue;
            }

            string className = "Advent2022.day" + day;
            Type type = Type.GetType(className);
            object instance = Activator.CreateInstance(type);
            type.GetMethod("Run").Invoke(instance, null);

            Console.Write("\nDo you want to pick another day? (y/n): ");
            string response = Console.ReadLine();

            if (response == "n")
            {
                break;
            }
        }
    }
}
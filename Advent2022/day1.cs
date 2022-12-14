namespace Advent2022
{
    internal class day1
    {
        public static void Run()
        {
            string[] input = File.ReadAllLines(@$"{Environment.CurrentDirectory}\Inputs\day1.txt");

            void Part1(string[] input)
            {
                int calories = 0;
                int maxCalories = 0;

                foreach (string line in input)
                {
                    if (line == "")
                    {
                        if (maxCalories <= calories)
                        {
                            maxCalories = calories;
                        }
                        calories = 0;
                    }
                    else
                    {
                        calories = calories + int.Parse(line);
                    }
                }
                Console.WriteLine($"a) {maxCalories}");
            }

            void Part2(string[] input)
            {
                List<int> caloriesList = new List<int>();
                int calories = 0;

                foreach (string line in input)
                {
                    if (line == "")
                    {
                        caloriesList.Add(calories);
                        calories = 0;
                    }
                    else
                    {
                        calories = calories + int.Parse(line);
                    }
                }
                var top3 = caloriesList.OrderByDescending(x => x).ToList();
                Console.WriteLine($"b) {top3[0] + top3[1] + top3[2]}");
            }

            Part1(input);
            Part2(input);
        }
    }
}

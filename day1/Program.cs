string[] input = File.ReadAllLines($"{Environment.CurrentDirectory}\\..\\..\\..\\day1.txt");

void MostCalories(string[] input )
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
    Console.WriteLine($"Max calories: {maxCalories}");
}

void TopThreeCalories(string[] input)
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
    Console.WriteLine($"Total calories carried by top 3 clowns: {top3[0] + top3[1] + top3[2]}");
}

TopThreeCalories(input);
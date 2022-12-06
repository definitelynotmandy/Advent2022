string[] input = File.ReadAllLines(@$"{Environment.CurrentDirectory}\day3.txt");

void Part1(string[] input)
{
    int total = 0;
    int index = 0;

    foreach (string line in input)
    {
        int halfLength = line.Length / 2;
        List<char> firstHalf = new List<char>();
        List<char> secondHalf = new List<char>();
        char commonLetter = '\0';

        for (int j=0; j<halfLength; j++) {
            firstHalf.Add(line[j]);
        }
        for (int k=halfLength; k<line.Length; k++)
        {
            secondHalf.Add(line[k]);
        }

        for (int l = 0; l <= firstHalf.Count-1; l++)
        {
            char firstLetter = firstHalf[l];
            for (int m = 0; m <= secondHalf.Count-1; m++)
            {
                if (firstLetter == secondHalf[m])
                {
                    commonLetter = secondHalf[m];
                }
            }
        }

        _ = char.IsLower(commonLetter) ? index = (int)commonLetter % 32 : index = ((int)commonLetter % 32) + 26;

        total = total + index;
    }
    Console.WriteLine($"Part 1: {total}");
}

void Part2(string[] input)
{
    List<List<string>> groups = GetGroups(input);
    int total = 0;

    foreach (List<string> group in groups)
    {
        var sack1 = group[0];
        var sack2 = group[1];
        var intersect = sack1.Intersect(sack2);
        var common = intersect.Intersect(group[2]);
        int index = 0;

        foreach (char letter in common)
        {
            _ = char.IsLower(letter) ? index = index + (int)letter % 32 : index = index + ((int)letter % 32) + 26;
        }

        total = total + index;
    }
    Console.WriteLine($"Part 2: {total}");

    List<List<string>> GetGroups(string[] input)
    {
        List<List<string>> groups = new();
        List<string> current = new ();
        foreach (string group in input)
        {
            current.Add(group);
            if (current.Count == 3)
            {
                groups.Add(current);
                current = new();
            }
        }
        return groups;
    }
}

Part1(input);
Part2(input);
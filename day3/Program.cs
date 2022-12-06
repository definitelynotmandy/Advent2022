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
    Console.WriteLine($"Total priority: {total}");
}

Part1(input);
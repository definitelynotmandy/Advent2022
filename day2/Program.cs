//one day when im smarter i will think of a more elegant way of reading a file but that sounds like a later-mandy's problem
string[] input = File.ReadAllLines($"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\day2.txt");

void Part1 (string[] input) { 
    char[] plays = new char[2];
    int totalScore = 0;

    foreach (string line in input )
    {
        plays[0] = char.Parse(line.Split(' ')[0]);
        plays[1] = char.Parse(line.Split(' ')[1]);

        totalScore = totalScore + GetOutcome(plays) + GetRPS(plays[1]);
    };

    int GetRPS(char ch)
    {
        return ch switch
        {
            'X' => 1,
            'Y' => 2,
            'Z' => 3
        };

    };

    int GetOutcome(char[] plays)
    {
        return (plays[0], plays[1]) switch
        {
            ('A', 'Y') or ('B', 'Z') or ('C', 'X') => 6,
            ('A', 'X') or ('B', 'Y') or ('C', 'Z') => 3,
            ('A', 'Z') or ('B', 'X') or ('C', 'Y') => 0
        };
    };

    Console.WriteLine($"The total score according the plan was: {totalScore}");
};

void Part2(string[] input)
{
    char[] plan = new char[2];
    int totalScore = 0;

    foreach (string line in input)
    {
        plan[0] = char.Parse(line.Split(' ')[0]);
        plan[1] = char.Parse(line.Split(' ')[1]);

        totalScore = totalScore + WhatToPlay(plan) + GetOutcome(plan[1]);
    };

    int GetOutcome(char ch)
    {
        return ch switch
        {
            'X' => 0,
            'Y' => 3,
            'Z' => 6
        };

    };

    int WhatToPlay(char[] plan)
    {
        return (plan[0], plan[1]) switch
        {
            ('A', 'Y') or ('B', 'X') or ('C', 'Z') => 1, // in the case that i need to play a rock (1 point)
            ('A', 'Z') or ('B', 'Y') or ('C', 'X') => 2, // in the case that i need to play a paper (2 points)
            ('A', 'X') or ('B', 'Z') or ('C', 'Y') => 3 // in the case that i need to play a scissor (3 points)
        };
    }

    Console.WriteLine($"The total score according the new plan was: {totalScore}");
};

Part1(input);
Part2(input);
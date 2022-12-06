namespace Advent2022
{
    internal class day2
    {
        public static void Run()
        {
            string[] input = File.ReadAllLines($@"{Environment.CurrentDirectory}\Inputs\day2.txt");

            void Part1(string[] input)
            {
                char[] plays = new char[2];
                int totalScore = 0;

                foreach (string line in input)
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

                Console.WriteLine($"\nDay 2\ta) {totalScore}");
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

                Console.WriteLine($"\tb) {totalScore}");
            };

            Part1(input);
            Part2(input);
        }
    }
}

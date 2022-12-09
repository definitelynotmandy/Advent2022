namespace Advent2022
{
    internal class day5
    {
        public static void Run()
        {
            var input = File.ReadAllText(@$"{Environment.CurrentDirectory}\Inputs\day5.txt").Split("").ToArray();

            var stacks1 = new List<Stack<char>>() {
                new Stack<char>(new[] { 'B', 'W', 'N' }),
                new Stack<char>(new[] { 'L', 'Z', 'S', 'P', 'T', 'D', 'M', 'B' }),
                new Stack<char>(new[] { 'Q', 'H', 'Z', 'W', 'R' }),
                new Stack<char>(new[] { 'W', 'D', 'V', 'J', 'Z', 'R' }),
                new Stack<char>(new[] { 'S', 'H', 'M', 'B' }),
                new Stack<char>(new[] { 'L', 'G', 'N', 'J', 'H', 'V', 'P', 'B' }),
                new Stack<char>(new[] { 'J', 'Q', 'Z', 'F', 'H', 'D', 'L', 'S' }),
                new Stack<char>(new[] { 'W', 'S', 'F', 'J', 'G', 'Q', 'B' }),
                new Stack<char>(new[] { 'Z', 'W', 'M', 'S', 'C', 'D', 'J' }),
            };

            foreach (var line in input)
            {
                var instruction = line.Split('\n').Select(x => x.Split(' ')).ToArray();

                for (int i = 10; i < instruction.Count(); i++)
                {
                    int number = int.Parse(instruction[i][1]);
                    int from = int.Parse(instruction[i][3]);
                    int to = int.Parse(instruction[i][5]);

                    while (number-- > 0)
                    {
                        stacks1[to - 1].Push(stacks1[from - 1].Pop());
                    }
                }

                Console.WriteLine($"\nDay5:\ta) {string.Join("", stacks1.Select(x => x.Peek()))}");
            }

        }
    }
}

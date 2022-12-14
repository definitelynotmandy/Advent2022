namespace Advent2022
{
    internal class day5
    {
        public static void Run()
        {
            var input = File.ReadAllText(@$"{Environment.CurrentDirectory}\Inputs\day5.txt").Split("").ToArray();

            var stacks = new List<Stack<char>>() {
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

            var stacks1 = stacks.Select(stack =>
            {
                char[] array = stack.ToArray();
                Array.Reverse(array);
                return new Stack<char>(array);
            }).ToList();
            var stacks2 = stacks.Select(stack =>
            {
                char[] array = stack.ToArray();
                Array.Reverse(array);
                return new Stack<char>(array);
            }).ToList();

            foreach (var line in input)
            {
                var instruction = line.Split('\n').Select(x => x.Split(' ')).ToArray();

                for (int i = 10; i < instruction.Count(); i++)
                {
                    int number = int.Parse(instruction[i][1]);
                    int from = int.Parse(instruction[i][3]);
                    int to = int.Parse(instruction[i][5]);
                    var extraStack = new Stack<char>();

                    while (number-- > 0)
                    {
                        stacks1[to - 1].Push(stacks1[from - 1].Pop());
                        extraStack.Push(stacks2[from - 1].Pop());
                    }
                    while (extraStack.Count > 0)
                    {
                        stacks2[to - 1].Push(extraStack.Pop());
                    }
                }

                Console.WriteLine($"a) {string.Join("", stacks1.Select(x => x.Peek()))}");
                Console.WriteLine($"b) {string.Join("", stacks2.Select(x => x.Peek()))}");
            }
        }
    }
}

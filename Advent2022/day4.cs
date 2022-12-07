namespace Advent2022
{
    internal class day4
    {
        public static void Run()
        {
            int overlap1 = 0;
            int overlap2 = 0;

            var input = File.ReadAllLines(@$"{Environment.CurrentDirectory}\Inputs\day4.txt").Select(x => x.Split(",").Select(y => y.Split("-").ToList()).ToList()).ToList(); // [ [[A] [b]] [[C] [D]] ] a list with 2 lists, with each 2 lists, total of 4 in a pair of clowns: start1 start2, end1 end2


            foreach (var pair in input)
            {
                _ = (((int.Parse(pair[1][0]) >= int.Parse(pair[0][0])) && (int.Parse(pair[1][1]) <= int.Parse(pair[0][1]))) || ((int.Parse(pair[1][0]) <= int.Parse(pair[0][0])) && (int.Parse(pair[1][1]) >= int.Parse(pair[0][1])))) ? overlap1++ : overlap1 + 0; //can you have a "do nothing if false" ternary?

            }

            foreach (var pair in input)
            {
                _ = (((int.Parse(pair[0][0]) <= int.Parse(pair[1][0])) && (int.Parse(pair[1][0]) <= int.Parse(pair[0][1]))) || ((int.Parse(pair[0][0]) <= int.Parse(pair[1][1])) && (int.Parse(pair[1][1]) <= int.Parse(pair[0][1]))) || ((int.Parse(pair[1][0]) <= int.Parse(pair[0][0])) && (int.Parse(pair[0][0]) <= int.Parse(pair[1][1]))) || ((int.Parse(pair[1][0]) <= int.Parse(pair[0][1])) && (int.Parse(pair[0][1]) <= int.Parse(pair[1][1])))) ? overlap2++ : overlap2 + 0;
            }

            Console.WriteLine($"\nDay 4\ta) {overlap1}\n\tb) {overlap2}");

        }

    }
}
   
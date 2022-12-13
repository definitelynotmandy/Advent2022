using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Advent2022
{
    internal class day6
    {
        public static void Run()
        {
            string input = File.ReadAllText(@$"{Environment.CurrentDirectory}\Inputs\day6.txt");

            // maybe one day i will be cool enough to make this into a something that takes in a value to do the beepboop magic and spit out the index kind of like gibIndexNow(n) where n is the length of the start marker
            // idk this is a mess but so am i
            int index1 = input.Select((c, i) => new { c, i })
                             .Where(x => x.i < input.Length - 3)
                             .First(x => input.Substring(x.i, 4).Distinct().Count() == 4)
                             .i;

            int index2 = input.Select((c, i) => new { c, i })
                             .Where(x => x.i < input.Length - 13)
                             .First(x => input.Substring(x.i, 14).Distinct().Count() == 14)
                             .i;

            Console.WriteLine($"\nDay6\ta) {index1 + 4}\n\tb) {index2 + 14}");
        }
    }
}

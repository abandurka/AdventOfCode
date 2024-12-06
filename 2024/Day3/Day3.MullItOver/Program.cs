using System.Text.RegularExpressions;
using AOC.Shared;

namespace Day3.MullItOver;

class Program
{
    static void Main(string[] args)
    {
        var lines = FileParser.LoadLines(StringConstants.DefaultPath);

        var regex = new Regex("mul\\((\\d+),(\\d+)\\)");
        var matches = lines
            .Select(x => regex.Matches(x))
            .SelectMany(f => f)
            .Select(x => Mul(x.Groups[1].Value, x.Groups[2].Value))
            .Sum();

        Console.WriteLine(matches);

        var regex2 = new Regex("mul\\((\\d+),(\\d+)\\)|do\\(\\)|don't\\(\\)");
        var matches2 = lines
            .Select(x => regex2.Matches(x))
            .SelectMany(f => f)
            ;

        var sum = 0;
        var enabled = true;
        foreach (var x in matches2)
        {
            switch (x.Groups[0].Value)
            {
                case "do()":
                    enabled = true;
                    continue;
                case "don't()":
                    enabled = false;
                    continue;
                
            }

            if (enabled && x.Groups[0].Value.StartsWith("mul"))
            {
                sum += Mul(x.Groups[1].Value, x.Groups[2].Value);
            }
        }
        

        Console.WriteLine($"sum2: {sum}");
    }

    private static int Mul(string l, string r)
    {
        return int.Parse(l) * int.Parse(r);
    }
}
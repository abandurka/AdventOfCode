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
            .Select(x=> regex.Matches(x))
            .SelectMany(f=> f)
            .Select(x=> Mul(x.Groups[1].Value, x.Groups[2].Value))
            .Sum();
    }

    private static int Mul(string l, string r)
    {
        return int.Parse(l) * int.Parse(r);
    }
}
using AOC.Shared;

namespace Day4.CeresSearch;

class Program
{
    static void Main(string[] args)
    {
        var t = new[]
        {
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX"
        };

        var lines = FileParser.LoadLines(StringConstants.DefaultPath);

        var count = 0;
        foreach (var word in Day4Solver.GetAllCharArrays(lines))
        {
            count += Day4Solver.Find(word);
        }

        Console.WriteLine($"Total count: {count}");
    }
}

public class Day4Solver
{
    private const string xmas = "XMAS";
    private static char[] xmasChars = xmas.ToCharArray();

    public static int Find(Span<Char> input)
    {
        return FindForward(input) == 1 ? 1 : FindBackward(input);
    }

    public static int FindForward(Span<char> input)
    {
        for (var i = 0; i < 4; i++)
        {
            if (input[i] != xmasChars[i])
            {
                return 0;
            }
        }
        return 1;
    }

    public static int FindBackward(Span<char> input)
    {
        for (var i = 0; i < 4; i++)
        {
            if (input[i] != xmasChars[3-i])
            {
                return 0;
            }
        }
        return 1;
    }

    public static IEnumerable<char[]> GetAllCharArrays(IEnumerable<string> lines)
    {
        var arr = lines.ToArray();
        var colCount = arr[0].Length;
        var rowCount = arr.Length;

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (CanBeHorizontal(colCount, j)) 
                {
                    yield return arr[i].Substring(j, 4).ToCharArray();
                }

                if (CanBeVertical(rowCount, i))
                {
                    yield return [arr[i][j], arr[i + 1][j], arr[i + 2][j], arr[i + 3][j]];
                }

                if (!CanBeHorizontal(colCount, j) || !CanBeVertical(rowCount, i))
                {
                    continue;
                }
                
                yield return [arr[i][j], arr[i + 1][j + 1], arr[i + 2][j + 2], arr[i + 3][j + 3]];
                yield return [arr[i][j + 3], arr[i + 1][j + 2], arr[i + 2][j + 1], arr[i + 3][j]];
            }
        }
    }

    private static bool CanBeVertical(int rowCount, int i) => rowCount > i + 3;
    private static bool CanBeHorizontal(int colCount, int j) => colCount > j + 3;
}
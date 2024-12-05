using AOC.Shared;

namespace Day2.RedNosedReports;

class Program
{
    static void Main(string[] args)
    {
        var vectors = FileParser.LoadLines(StringConstants.DefaultPath, s => DataParsers.AsInt(s))
            .ToList();

        var ans = vectors.Where(Day2Solver.IsSafe)
            .Count();
        
        Console.WriteLine($"Safe vectors count: {ans}");

        var ans2 = vectors.Where(Day2Solver.IsSafeWithReduction)
            .Count();
        
        Console.WriteLine($"Safe with reduction vectors count: {ans2}");
    }

}

public class Day2Solver
{
    public enum Direction
    {
        undefined, asc, desc
    }
    
    public static bool IsSafe(int[] vector)
    {
        var direction = GetDirection(vector);

        return IsSafeWithDirection(vector, direction);
    }
    
    public static bool IsSafeWithReduction(int[] vector)
    {
        var direction = GetDirection(vector);

        for (int i = 0; i < vector.Length - 1; i++)
        {
            var current = vector[i];
            var next = vector[i + 1];

            if (!HasValidDiff(current, next) || !IsValidDirection(current, next, direction) )
            {
                var newVector = NewVector(vector, i);
                var v1 = IsSafeWithDirection(newVector, GetDirection(newVector));
                var newVector2 = NewVector(vector, i + 1);
                var v2 = IsSafeWithDirection(newVector2, GetDirection(newVector2));
                
                return v1 || v2;
            }

            
        }

        return true;
    }

    private static int[] NewVector(int[] vector, int i) => 
        vector[ .. i].Concat(vector[(i + 1) ..]).ToArray();

    private static Direction GetDirection(int a, int b) => 
        a > b ? Direction.desc : Direction.asc;

    private static Direction GetDirection(int[] vector) =>
        GetDirection(vector[0], vector[^1]);

    public static bool IsSafeWithDirection(int[] vector, Direction direction)
    {
        for (int i = 0; i < vector.Length - 1; i++)
        {
            var current = vector[i];
            var next = vector[i + 1];

            if (!IsValidDirection(current, next, direction) || !HasValidDiff(current, next))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsValidDirection(int a, int b, Direction direction) =>
        GetDirection(a,b) == direction;

    public static bool HasValidDiff(int a, int b) => Math.Abs(a - b) is < 4 and > 0;
}
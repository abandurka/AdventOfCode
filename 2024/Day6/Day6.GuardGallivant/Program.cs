using AOC.Shared;

namespace Day6.GuardGallivant;

class Program
{

    static void Main(string[] args)
    {
        var lines = FileParser
            .LoadLines(StringConstants.DefaultPath, s => s.ToCharArray())
            .ToArray();

        var (row, col, direction) = GetStartingPosition(lines);

        var steps = new HashSet<(int, int)>();
        while (true)
        {
            var step = Solver.GetStep(direction);
            
            if (Solver.IsOutOfBounds(lines, row + step.row, col+ step.col, direction))
            {
                break;
            }

            (row, col, direction) = Solver.GetNextStep(lines, row, col, direction);
            steps.Add((row,col));
        }

        Console.WriteLine($"Day 6: Guard Gallivant = {steps.Count()}");
    }

    private static (int row, int col, Solver.Direction direction) GetStartingPosition(char[][] lines)
    {
        var col = 0;
        var row = 0;
        for (var i = 0; i < lines.Length; i++)
        {
            for (var index = 0; index < lines[i].Length; index++)
            {
                if (Solver.TryGetDirection(lines[i][index], out var direction))
                {
                    return (row, col, direction);
                }

                col++;
            }

            row++;
            col = 0;
        }

        return (-1, -1, 0);
    }
}

public class Solver
{
    
    public enum Direction
    {
        Undefined = 0,
        Up,
        Right,
        Down,
        Left
    }
    public static bool TryGetDirection(char p, out Direction direction)
    {
        direction = p switch
        {
            '^' => Direction.Up,
            'v' => Direction.Down,
            '>' => Direction.Right,
            '<' => Direction.Left,
            _ => Direction.Undefined
        };
        
        return direction != default;
    }

    public static (int row, int col, Direction direction) GetNextStep(char[][] lines, int row, int col, Direction direction)
    {
        if (direction == Direction.Up)
        {
            var nextRow = row - 1;
            return IsSafePlace(lines, nextRow, col) 
                ? (nextRow, col, direction) 
                : TurnRight(row, col, direction);
        }
        
        
        if (direction == Direction.Down)
        {
            var nextRow = row + 1;
            return IsSafePlace(lines, nextRow, col) 
                ? (nextRow, col, direction) 
                : TurnRight(row, col, direction);
        }
        
        if (direction == Direction.Right)
        {
            var nextCol = col + 1;
            return IsSafePlace(lines, row, nextCol) 
                ? (row, nextCol, direction) 
                : TurnRight(row, col, direction);
        }
        
        if (direction == Direction.Left)
        {
            var nextCol = col - 1;
            return IsSafePlace(lines, row, nextCol) 
                ? (row, nextCol, direction) 
                : TurnRight(row, col, direction);
        }

        return (-1, -1, direction);
    }

    public static (int row, int col, Direction direction) TurnRight(int row, int col, Direction direction)
    {
        var nextDirection = GetNextDirection(direction);
        var step = GetStep(nextDirection);
        return (row + step.row, col + step.col,nextDirection);
    }

    public static Direction GetNextDirection(Direction direction) =>
        direction  switch
        {
            Direction.Up => Direction.Right,
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Up,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

    private static bool IsSafePlace(char[][] lines, int nextRow, int col) => 
        lines[nextRow][col] != '#';

    public static bool IsOutOfBounds(char[][] lines, int row, int col, Direction direction) => 
        row < 0 || col < 0 || row >= lines.Length || col >= lines[0].Length;

    public static (int row, int col) GetStep(Direction direction) =>
        direction switch
        {
            Direction.Up => (- 1, 0),
            Direction.Down => (+ 1, 0),
            Direction.Left => (0, - 1),
            Direction.Right => (0, + 1),
            _ => (0, 0)
        };
}


using Day6.GuardGallivant;

namespace AOC.Shared.Tests;

[Category("Day6")]
public class Day6Tests
{
    [Test]
    [Arguments(Solver.Direction.Up, Solver.Direction.Right)]
    [Arguments(Solver.Direction.Right, Solver.Direction.Down)]
    [Arguments(Solver.Direction.Down, Solver.Direction.Left)]
    [Arguments(Solver.Direction.Left, Solver.Direction.Up)]
    public async Task GetNextDirection(Solver.Direction input, Solver.Direction expected)
    {
        var result = Solver.GetNextDirection(input);

        await Assert.That(result).IsEqualTo(expected);
    }
    
    [Test]
    [Arguments('^', Solver.Direction.Up, true)]
    [Arguments('>', Solver.Direction.Right, true)]
    [Arguments('<', Solver.Direction.Left, true)]
    [Arguments('v', Solver.Direction.Down, true)]
    [Arguments('.', Solver.Direction.Undefined, false)]
    public async Task TryGetNextDirection(char input, Solver.Direction expected, bool validExpected)
    {
        var result2 = Solver.TryGetDirection(input, out var result);

        using (var assert = Assert.Multiple())
        {
            await Assert.That(result).IsEqualTo(expected);
            await Assert.That(result2).IsEqualTo(validExpected);
        }
    } 
}
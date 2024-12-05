using Day2.RedNosedReports;

namespace AOC.Shared.Tests;

[Category("Day2")]
public class Day2Tests
{
    [Test]
    [Arguments(new[] {7, 6, 4, 2, 1} , true)]
    [Arguments(new[] {1, 2, 7, 8, 9} , false)]
    [Arguments(new[] {9, 7, 6, 2, 1} , false)]
    [Arguments(new[] {1, 3, 2, 4, 5} , false)]
    [Arguments(new[] {8, 6, 4, 4, 1} , false)]
    [Arguments(new[] {1, 3, 6, 7, 9} , true)]
    public async Task IsSafe_OnVector_ReturnsValid(int[] vector, bool isSafe)
    {
        var result = Day2Solver.IsSafe(vector);

        await Assert.That(result).IsEqualTo(isSafe, $"{vector}: {isSafe}");
    }
    
    [Test]
    [Arguments(new[] {7, 6, 4, 2, 1} , true)]
    [Arguments(new[] {1, 2, 7, 8, 9} , false)]
    [Arguments(new[] {9, 7, 6, 2, 1} , false)]
    [Arguments(new[] {1, 3, 2, 4, 5} , true)]
    [Arguments(new[] {8, 6, 4, 4, 1} , true)]
    [Arguments(new[] {1, 3, 6, 7, 9} , true)]
    [Arguments(new[] {4, 3, 6, 7, 9} , true)]
    [Arguments(new[] {9, 10, 6, 2, 1} , false)]
    [Arguments(new[] {1, 2, 3, 4, 100} , true)]
    [Arguments(new[] {1, 20, 3, 4, 100} , false)]
    [Arguments(new[] {100, 2, 3, 4, 5} , true)]    
    [Arguments(new[] {100, 2, 3, 4, 3} , false)]
    [Arguments(new[] {100, 2, 3, 4, 0} , false)]

    public async Task IsSafeWithReduction_OnVector_ReturnsValid(int[] vector, bool isSafe)
    {
        var result = Day2Solver.IsSafeWithReduction(vector);

        await Assert.That(result).IsEqualTo(isSafe).Because($"{string.Join(',', vector)}: {isSafe}");
    }
}
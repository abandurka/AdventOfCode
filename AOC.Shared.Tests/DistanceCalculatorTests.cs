using Day1.HistorianHysteria.Console;

namespace AOC.Shared.Tests;

[Category("Day1.HistorianHysteria")]
public class DistanceCalculatorTests
{
    [Test]
    [Arguments(1, 1, 0)]
    [Arguments(2, 1, 1)]
    [Arguments(1, 2, 1)]
    public async Task GetDistance_OnPositiveValues_ReturnsPositive(int l, int r, int expectedDistance)
    {
        var result = DistanceCalculator.GetDistance(l, r);

        await Assert.That(result).IsEqualTo(expectedDistance);
    }
}
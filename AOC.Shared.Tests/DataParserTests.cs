using FluentAssertions;

namespace AOC.Shared.Tests;

[Category("Shared")]
public class DataParserTests
{
    [Test]
    [Arguments("", new int[0])]
    [Arguments("1", new[]{ 1 })]
    [Arguments("1 2", new[]{ 1 , 2 })]
    [Arguments("1   2", new[]{ 1 , 2 })]
    public async Task GetDistance_OnPositiveValues_ReturnsPositive(string str, int[] expectedResult)
    {
        var result = DataParsers.AsInt(str);

        await Assert
            .That(() => result.Should().BeEquivalentTo(expectedResult))
            .ThrowsNothing();
    }
}
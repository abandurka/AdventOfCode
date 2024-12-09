using Day4.CeresSearch;

namespace AOC.Shared.Tests;

[Category("Day4")]
public class Day4Tests
{
    [Test]
    [Arguments("XMAS", 1)]
    [Arguments("SMAX", 0)]
    public async Task FindForward_OnStr_ReturnsValid(string input, int valid)
    {
        var result = Day4Solver.FindForward(input.ToCharArray());

        await Assert.That(result).IsEqualTo(valid);
    }    
    
    [Test]
    [Arguments("XMAS", 1)]
    [Arguments("SAMX", 1)]
    public async Task Find_OnStr_ReturnsValid(string input, int valid)
    {
        var result = Day4Solver.Find(input.ToCharArray());

        await Assert.That(result).IsEqualTo(valid);
    }
    
        [Test]
        [Arguments("XMAS", 0)]
        [Arguments("SAMX", 1)]
        public async Task FindBackward_OnStr_ReturnsValid(string input, int valid)
        {
            var result = Day4Solver.FindBackward(input.ToCharArray());
    
            await Assert.That(result).IsEqualTo(valid);
        }
}
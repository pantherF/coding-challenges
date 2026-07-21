using Solutions.FreeCodeCampDailyChallenges;

namespace Solutions.Tests;

public class RoundToNearestMultipleTest
{
    [Fact]
    public void FirstGreaterThanSecond_ThrowsException()
    {
        uint a = 3;
        uint b = 5;

        var exception = Assert.Throws<Exception>(() => RoundToNearestMultiple.Round(a, b));

        Assert.Equal("First must be greater than second.", exception.Message);
    }

    [Theory]
    [InlineData(5, 3, 6)]
    [InlineData(17, 4, 16)]
    [InlineData(43, 5, 45)]
    [InlineData(38, 11, 33)]
    [InlineData(93, 12, 96)]
    public void RoundToNearestMultiple_VariousInputs_ReturnsExpected(uint a, uint b, uint expected)
    {
        uint result = RoundToNearestMultiple.Round(a, b);
        Assert.Equal(expected, result);
    }
}
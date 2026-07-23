using Solutions.FreeCodeCampDailyChallenges;

namespace Solutions.Tests.FreeCodeCampDailyChallenges;

public class PrimeFactorizationTest
{
    public static IEnumerable<object[]> RoundTestCases =>
        new List<object[]>
        {
            new object[] { 20, new List<uint> { 2, 2, 5 } },
            new object[] { 15, new List<uint> { 3, 5 } },
            new object[] { 17, new List<uint> { 17 } },
            new object[] { 35, new List<uint> { 5, 7 } },
            new object[] { 999, new List<uint> { 3, 3, 3, 37 } },
            new object[] { 510510, new List<uint> { 2, 3, 5, 7, 11, 13, 17 } },
        };

    [Theory]
    [MemberData(nameof(RoundTestCases))]
    public void PrimeFactorization_VariousInputs_ReturnsExpected(uint input, List<uint> expected)
    {
        var result = PrimeFactorization.PrimeFactors(input);
        Assert.Equal(expected, result);
    }
}
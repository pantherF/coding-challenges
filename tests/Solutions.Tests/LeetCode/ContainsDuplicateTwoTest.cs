using Solutions.LeetCode;

namespace Solutions.Tests.LeetCode;

public class ContainsDuplicateTwoTest
{
    readonly int[] _arr = { 1, 2, 3, 1, 2, 3 };

    public static IEnumerable<object[]> TrueTestCases =>
    new List<object[]>
    {
            new object[] { new int[] { 1, 2, 3, 1 }, 3 },
            new object[] { new int[] { 1, 0, 1, 1 }, 1 },
            new object[] { new int[] { 1, 4, 2, 3, 1, 2 }, 3 },
            new object[] { new int[] { 99, 99,}, 2 },
    };

    [Theory]
    [MemberData(nameof(TrueTestCases))]
    public void ONTimesK_ReturnTrue(int[] arr, int k)
    {
        var result = ContainsDuplicateTwo.ONTimesK(arr, k);
        Assert.True(result);
    }

    [Fact]
    public void ONTimesK_ReturnFalse()
    {
        int k = 2;

        var result = ContainsDuplicateTwo.ONTimesK(_arr, k);

        Assert.False(result);
    }

    [Theory]
    [MemberData(nameof(TrueTestCases))]
    public void ONLogK_ReturnTrue(int[] arr, int k)
    {
        var result = ContainsDuplicateTwo.ONLogK(arr, k);
        Assert.True(result);
    }

    [Fact]
    public void ONLogK_ReturnFalse()
    {
        int k = 2;

        var result = ContainsDuplicateTwo.ONLogK(_arr, k);

        Assert.False(result);
    }


    [Theory]
    [MemberData(nameof(TrueTestCases))]
    public void ON_ReturnTrue(int[] arr, int k)
    {
        var result = ContainsDuplicateTwo.ON(arr, k);
        Assert.True(result);
    }

    [Fact]
    public void ON_ReturnFalse()
    {
        int k = 2;

        var result = ContainsDuplicateTwo.ON(_arr, k);

        Assert.False(result);
    }
}
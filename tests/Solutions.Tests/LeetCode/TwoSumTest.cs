using Solutions.LeetCode;

namespace Solutions.Tests.LeetCode;

public class TwoSumTest
{
    public static IEnumerable<object[]> TestCases =>
    new List<object[]>
    {
            new object[] { new int[] { 3, 3 }, 6, new int[] { 0, 1 } },
            new object[] { new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 }  },
            new object[] { new int[] { 2, 4, 11, 3 }, 6, new int[] { 0, 1 }  },
            new object[] { new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 } },
            new object[] { new int[] { 2, 15, 2 }, 100, new int[] { 0, 0 } },
    };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void ONSquared_ReturnTrue(int[] arr, int k, int[] expected)
    {
        var actual = TwoSum.ONSquared(arr, k);
        Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x));
    }

    [Theory]
    [MemberData(nameof(TestCases))]
    public void ON_ReturnTrue(int[] arr, int k, int[] expected)
    {
        var actual = TwoSum.ON(arr, k);
        Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x));
    }
}
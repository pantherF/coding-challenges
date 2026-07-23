namespace Solutions.LeetCode;

public static class ContainsDuplicate
{
    // Here I don't try the brute force approach, nor the sorting approach,
    // which is one time complexity better, I try to find the optimal solution right away
    public static bool ON(int[] nums)
    {
        var map = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (map.Contains(nums[i]))
            {
                return true;
            }

            map.Add(nums[i]);
        }

        return false;
    }

    // I looked at other leetcode solutions faster than mine and found this one
    // that used a foreach loop and initialized the length of the hashset prior to
    // adding anything to it, aka filling it dynamically. I cut 15 ms down to 8
    // and even space complexity got better.
    // I then learned, this is because the re-computation of the hash-sets size is eliminated,
    // prettyyy clever stuff.
    public static bool ONFaster(int[] nums)
    {
        var map = new HashSet<int>(nums.Length);

        foreach (var num in nums)
        {
            if (map.Contains(num))
            {
                return true;
            }

            map.Add(num);
        }

        return false;
    }
}
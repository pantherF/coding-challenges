namespace Solutions.LeetCode;

public static class ContainsDuplicate
{
    public static bool Check(int[] nums)
    {
        Array.Sort(nums);

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
}
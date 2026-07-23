namespace Solutions.LeetCode;

public static class ContainsDuplicateTwo
{
    public static bool ONTimesK(int[] nums, int k)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length && Math.Abs(i - j) <= k; j++)
            {
                if (nums[i] == nums[j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    // Fails two tests at the moment
    public static bool ONLogK(int[] nums, int k)
    {
        for (int i = 0; i < nums.Length; i += k + 1)
        {
            int[] temp = new int[k];
            for (int j = 1; j <= k; j++)
            {
                temp[j - 1] = nums[i + j];

                if (i + j == nums.Length)
                {
                    break;
                }
            }

            Array.Sort(temp);

            if (Array.BinarySearch(temp, nums[i]) >= 0)
            {
                return true;
            }
        }

        return false;
    }

    public static bool ON(int[] nums, int k)
    {
        var set = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (set.Contains(nums[i]))
            {
                return true;
            }

            set.Add(nums[i]);

            if (set.Count > k)
            {
                set.Remove(nums[i - k]);
            }
        }

        return false;
    }
}
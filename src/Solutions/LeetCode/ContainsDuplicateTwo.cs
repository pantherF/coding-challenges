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

    public static bool ONLogK(int[] nums, int k)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            var size = Math.Min(nums.Length - (i + 1), k);
            int[] temp = new int[size];
            for (int j = 1; j <= size; j++)
            {
                temp[j - 1] = nums[i + j];
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
        var set = new HashSet<int>(nums.Length);

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
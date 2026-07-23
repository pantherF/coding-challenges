namespace Solutions.LeetCode;

// Problem: https://leetcode.com/problems/two-sum/description/?utm_source=instabyte.io&utm_medium=referral&utm_campaign=interview-master-100
public static class TwoSum
{
    public static int[] ONSquared(int[] numbers, int target)
    {
        int[] solution = [0, 0];

        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[i] + numbers[j] == target && i != j)
                {
                    solution[0] = i;
                    solution[1] = j;
                    break;
                }
            }
        }

        return solution;
    }

    public static int[] ON(int[] numbers, int target)
    {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (map.TryGetValue(target - numbers[i], out var index))
            {
                return [index, i];
            }

            map[numbers[i]] = i;
        }

        return [0, 0];
    }
}
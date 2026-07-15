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
                if (numbers[i] + numbers[j] == target)
                {
                    solution[0] = i;
                    solution[1] = j;
                    break;
                }
            }
        }

        return solution;
    }

    public static int[] ONLogN(int[] numbers, int target)
    {
        int[] solution = [0, 0];

        Array.Sort(numbers);

        for (int i = 0; i < numbers.Length; i++)
        {
            var find = target - numbers[i];
            solution[0] = i;
            solution[1] = Array.BinarySearch(numbers, find);

            if (solution[1] > 0)
            {
                break;
            }
        }

        return solution;
    }

    public static int[] ON(int[] numbers, int target)
    {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            map.Add(numbers[i], i);

            if (map.TryGetValue(Math.Abs(numbers[i] - target), out int value))
            {
                return [map[numbers[i]], value];
            }
        }

        return [0, 0];
    }
}
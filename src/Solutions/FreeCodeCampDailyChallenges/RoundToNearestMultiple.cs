namespace Solutions.FreeCodeCampDailyChallenges;

public static class RoundToNearestMultiple
{
    public static uint Round(uint first, uint second)
    {
        if (first <= second)
        {
            throw new Exception("first must be greater than second");
        }

        var length = first * second;
        var differences = new Dictionary<uint, uint>();

        uint iterator = 0;
        uint previousDifference = first - second;
        uint difference = 0;

        while (true)
        {
            iterator++;
            var multiplied = iterator * second;
            if (multiplied == first)
            {
                return multiplied;
            }

            if (multiplied < first)
            {
                difference = first - multiplied;

                differences.Add(multiplied, difference);

                if (previousDifference < difference)
                {
                    break;
                }

                previousDifference = difference;
            }

            if (multiplied > first)
            {
                difference = multiplied - first;

                differences.Add(multiplied, difference);

                if (previousDifference < difference)
                {
                    break;
                }

                previousDifference = difference;
            }
        }

        return differences.MinBy(p => p.Value).Key;
    }
}

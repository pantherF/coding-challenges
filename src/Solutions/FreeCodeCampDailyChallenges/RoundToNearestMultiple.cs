static uint RoundToNearestMultiple(uint first, uint second)
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

    while(true)
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

Console.WriteLine(RoundToNearestMultiple(5, 3));
Console.WriteLine(RoundToNearestMultiple(17, 4));
Console.WriteLine(RoundToNearestMultiple(20, 4));
Console.WriteLine(RoundToNearestMultiple(43, 5));
Console.WriteLine(RoundToNearestMultiple(38, 11));
Console.WriteLine(RoundToNearestMultiple(93, 12));
Console.WriteLine(RoundToNearestMultiple(130, 12));

// test:
// 1. roundToNearestMultiple(5, 3) should return 6.
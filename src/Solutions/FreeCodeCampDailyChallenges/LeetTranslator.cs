namespace Solutions.FreeCodeCampDailyChallenges;

public static class LeetTranslator
{
    public static string Translate(string input)
    {
        var leetTable = new Dictionary<char, int>
        {
            { 'a', 4 },
            { 'e', 3 },
            { 'g', 9 },
            { 'i', 1 },
            { 'l', 1 },
            { 'o', 0 },
            { 's', 5 },
            { 't', 7 }
        };

        var lower = input.ToLower();
        var leetWord = new List<char>();

        foreach (var letter in lower)
        {
            string stringValue = letter.ToString();
            if (leetTable.TryGetValue(letter, out var value))
            {
                stringValue = value.ToString();
            }

            leetWord.Add(stringValue[0]);
        }

        return new(leetWord.ToArray());
    }

}

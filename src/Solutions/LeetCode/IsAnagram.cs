using System.Runtime.CompilerServices;

namespace Solutions.LeetCode;

class Counters
{
    public int CountS;
    public int CountT;
}

public static class IsAnagram
{
    /// <summary>
    /// Very simple, only assures the same characters are present.
    /// Not suited for the anagram problem.
    /// </summary>
    /// <param name="s">The word to compare against.</param>
    /// <param name="t">The word to check for potentially being an anagram of s.</param>
    /// <returns>True if an anagram is found, false if not.</returns>
    public static bool Basic(string s, string t)
    {
        if (s.Length != t.Length) return false;

        foreach (var y in t)
        {
            if (!s.Contains(y))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// My first- unoptimized take at the problem.
    /// </summary>
    /// <param name="s">The word to compare against.</param>
    /// <param name="t">The word to check for potentially being an anagram of s.</param>
    /// <returns>True if an anagram is found, false if not.</returns>
    public static bool Is(string s, string t)
    {
        if (s.Length != t.Length) return false;

        s = s.ToLower();
        t = t.ToLower();

        Dictionary<char, Counters> map = Enumerable.Range('a', 26)
            .ToDictionary(i => (char)i, i => new Counters());

        for (int i = 0; i < s.Length; i++)
        {
            map[t[i]].CountT++;
            map[s[i]].CountS++;
        }

        foreach (var character in map)
        {
            if (character.Value.CountS != character.Value.CountT)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// This is my best shot at implementing a Unicode friendly solution.
    /// It runs with decent runtime, beating 58% of implementations on leetcode at the moment.
    /// </summary>
    /// <param name="s">The word to compare against.</param>
    /// <param name="t">The word to check for potentially being an anagram of s.</param>
    /// <returns>True if an anagram is found, false if not.</returns>
    public static bool Unicode(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var map = new Dictionary<char, int>(s.Length);
        var counter = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (map.TryGetValue(s[i], out var sValue))
            {
                map[s[i]] = sValue + 1;
                if (sValue == 0) counter++;
                else if (sValue + 1 == 0) counter--;
            }
            else
            {
                map[s[i]] = 1;
                counter++;
            }

            if (map.TryGetValue(t[i], out var tValue))
            {
                map[t[i]] = tValue - 1;
                if (tValue == 0) counter++;
                else if (tValue - 1 == 0) counter--;
            }
            else
            {
                map[t[i]] = -1;
                counter++;
            }
        }

        if (counter != 0)
        {
            return false;
        }

        return true;
    }


    /// <summary>
    /// This is the simplest solution code-wise, though still not the fastest.
    /// I wonder if a more efficient sorting algorithm can help us here.
    /// </summary>
    /// <param name="s">The word to compare against.</param>
    /// <param name="t">The word to check for potentially being an anagram of s.</param>
    /// <returns>True if an anagram is found, false if not.</returns>
    public static bool Sorting(string s, string t)
    {
        if (s.Length != t.Length) return false;

        if (SortString(s) != SortString(t))
        {
            return false;
        }

        return true;
    }

    static string SortString(string input)
    {
        char[] characters = [.. input];
        Array.Sort(characters);
        return new string(characters);
    }


    /// <summary>
    /// The fastest time complexity implementation for this problem.
    /// </summary>
    /// <param name="s">The word to compare against.</param>
    /// <param name="t">The word to check for potentially being an anagram of s.</param>
    /// <returns>True if an anagram is found, false if not.</returns>
    public static bool O1(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var alphabet = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            alphabet[s[i] - 'a']++;
            alphabet[t[i] - 'a']--;
        }

        foreach (var number in alphabet)
        {
            if (number != 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Slower than the above solution, although it is theoretically simpler, as the loop is only done once.
    /// The difference can be seen in 43.07 memory usage for this solution, compared to 43.45 for the above.
    /// Because faster runtime is generally valued ofer less space usage, the O1 implementation is the winner.
    /// Not to mention, that one is truly O(1), the below is not. it runs a millisecond slower than the above :D
    /// </summary>
    /// <param name="s">The word to compare against.</param>
    /// <param name="t">The word to check for potentially being an anagram of s.</param>
    /// <returns>True if an anagram is found, false if not.</returns>
    public static bool O1Simple(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var alphabet = new int[26];
        var counter = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (alphabet[s[i] - 'a'] == 0) counter++;
            else if (alphabet[s[i] - 'a'] == -1) counter--;
            alphabet[s[i] - 'a']++;

            if (alphabet[t[i] - 'a'] == 0) counter++;
            else if (alphabet[t[i] - 'a'] == 1) counter--;
            alphabet[t[i] - 'a']--;
        }

        return counter == 0;
    }
}
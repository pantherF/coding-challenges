using System.Runtime.CompilerServices;

namespace Solutions.LeetCode;

class Counters
{
    public int CountS;
    public int CountT;
}

public static class IsAnagram
{
    // Very simple, only assures the same characters are present.
    // Not suited for the anagram problem.
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


    // This is the simplest solution code-wise, though still not the fastest.
    // I wonder if a more efficient sorting algorithm can help us here.
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
}
using Solutions.LeetCode;

namespace Solutions.Tests.LeetCode;

public class IsAnagramTest
{
    public static IEnumerable<object[]> TrueCases =>
    new List<object[]>
    {
        new object[] { "cat", "tac"},
        new object[] { "greaTestofalLtime", "allgreatestofTime"},
    };

    public static IEnumerable<object[]> TrueUnicodeCases =>
    new List<object[]>
    {
        new object[] { "cat", "tac"},

        // Accented / non-ASCII Latin characters
        new object[] { "café", "éfac"},

        // Non-Latin script (Cyrillic)
        new object[] { "привет", "тевирп"},

        // Non-Latin script (Japanese, mixed scripts)
        new object[] { "こんにちは", "はちにんこ"},

        // Emoji (see note below on surrogate pairs)
        new object[] { "😀😂", "😂😀"},

        // Symbols / punctuation mixed with letters
        new object[] { "a!b@c#", "c#b@a!"},

        // Empty strings — trivially anagrams of each other
        new object[] { "", "" },
    };

    public static IEnumerable<object[]> FalseCases =>
    new List<object[]>
    {
        new object[] { "acaa", "caac"},
        new object[] { "aabbbb", "aaaabb"},
        new object[] { "rat", "car"},
    };

    public static IEnumerable<object[]> FalseUnicodeCases =>
    new List<object[]>
    {
        // Same letters, different case — 'A' and 'a' are different chars
        new object[] { "Cat", "tac"},

        // Visually similar but different Unicode code points
        // (Cyrillic 'а' U+0430 vs Latin 'a' U+0061)
        new object[] { "cat", "cаt"},

        // Same base letter, different accents
        new object[] { "café", "cafe"},

        // Same visible glyph, different normalization form:
        // "é" as one code point (U+00E9) vs "e" + combining accent (U+0065 U+0301)
        new object[] { "café", "cafe\u0301"},

        // Different length after accounting for surrogate pairs
        new object[] { "😀", "😀😀"},
    };

    [Theory]
    [MemberData(nameof(TrueCases))]
    public void Is_ReturnTrue(string s, string t)
    {
        var actual = IsAnagram.Is(s, t);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(FalseCases))]
    public void Is_ReturnFalse(string s, string t)
    {
        var actual = IsAnagram.Is(s, t);
        Assert.False(actual);
    }

    [Theory]
    [MemberData(nameof(TrueUnicodeCases))]
    public void Unicode_ReturnTrue(string s, string t)
    {
        var actual = IsAnagram.Unicode(s, t);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(FalseUnicodeCases))]
    public void Unicode_ReturnFalse(string s, string t)
    {
        var actual = IsAnagram.Unicode(s, t);
        Assert.False(actual);
    }


    [Theory]
    [MemberData(nameof(TrueCases))]
    public void O1_ReturnTrue(string s, string t)
    {
        var actual = IsAnagram.O1(s, t);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(FalseCases))]
    public void O1ReturnFalse(string s, string t)
    {
        var actual = IsAnagram.O1(s, t);
        Assert.False(actual);
    }
}
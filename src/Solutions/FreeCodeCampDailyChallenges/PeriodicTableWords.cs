namespace Solutions.FreeCodeCampDailyChallenges;

public static class PeriodicTableWords
{
    private static bool TwoLetterMatch(string[] sequence, string check)
    {
        return sequence.Any(s => s.Equals(check, StringComparison.OrdinalIgnoreCase));
    }

    public static bool CanSpell(string input)
    {
        string[] periodicTableElements =
        [
            "H",   "He",  "Li",  "Be",  "B",   "C",   "N",   "O",   "F",   "Ne",
            "Na",  "Mg",  "Al",  "Si",  "P",   "S",   "Cl",  "Ar",  "K",   "Ca",
            "Sc",  "Ti",  "V",   "Cr",  "Mn",  "Fe",  "Co",  "Ni",  "Cu",  "Zn",
            "Ga",  "Ge",  "As",  "Se",  "Br",  "Kr",  "Rb",  "Sr",  "Y",   "Zr",
            "Nb",  "Mo",  "Tc",  "Ru",  "Rh",  "Pd",  "Ag",  "Cd",  "In",  "Sn",
            "Sb",  "Te",  "I",   "Xe",  "Cs",  "Ba",  "La",  "Ce",  "Pr",  "Nd",
            "Pm",  "Sm",  "Eu",  "Gd",  "Tb",  "Dy",  "Ho",  "Er",  "Tm",  "Yb",
            "Lu",  "Hf",  "Ta",  "W",   "Re",  "Os",  "Ir",  "Pt",  "Au",  "Hg",
            "Tl",  "Pb",  "Bi",  "Po",  "At",  "Rn",  "Fr",  "Ra",  "Ac",  "Th",
            "Pa",  "U",   "Np",  "Pu",  "Am",  "Cm",  "Bk",  "Cf",  "Es",  "Fm",
            "Md",  "No",  "Lr",  "Rf",  "Db",  "Sg",  "Bh",  "Hs",  "Mt",  "Ds",
            "Rg",  "Cn",  "Nh",  "Fl",  "Mc",  "Lv",  "Ts",  "Og"
        ];

        string[] oneLetterElements = [.. periodicTableElements.Where(s => s.Length == 1)];
        string[] twoLetterElements = periodicTableElements.Where(s => s.Length == 2).ToArray();

        var chars = input.ToLower().ToArray();
        var match = new List<string> { };

        for (int i = 0; i < chars.Length; i++)
        {
            var thisChar = chars[i].ToString();
            var oneLetterMatch = false;

            foreach (var one in oneLetterElements)
            {
                if (one.ToLower() == thisChar)
                {
                    if (i + 1 >= chars.Length)
                    {
                        match.Add(thisChar);
                        break;
                    }

                    var both = $"{chars[i]}{chars[i + 1]}";

                    if (TwoLetterMatch(twoLetterElements, both))
                    {
                        match.Add(both);
                        i += 1;
                        continue;
                    }

                    oneLetterMatch = true;
                    match.Add(thisChar);
                }
            }

            if (oneLetterMatch == false)
            {
                if (i + 1 >= chars.Length)
                {
                    break;
                }

                var both = $"{chars[i]}{chars[i + 1]}";

                if (TwoLetterMatch(twoLetterElements, both))
                {
                    match.Add(both);
                    i += 1;
                }
            }

            if (i + 1 == chars.Length)
            {
                break;
            }
        }

        var matched = string.Join("", match);

        string cleanedInput = new([.. input.Where(char.IsLetter)]);
        string cleanedMatches = new(matched.Where(char.IsLetter).ToArray());

        if (cleanedInput == cleanedMatches)
        {
            return true;
        }

        return false;
    }
}

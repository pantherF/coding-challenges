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

Console.WriteLine("Put in a word:");
var input = Console.ReadLine();

if (string.IsNullOrEmpty(input))
{
    Console.WriteLine("Put in something, damn it!");
    return;
}

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

foreach (var item in match)
{
    Console.WriteLine(item);
}

var wrong = true;
var matched = string.Join("", match);

string cleanedInput = new([.. input.Where(char.IsLetter)]);
string cleanedMatches = new(matched.Where(char.IsLetter).ToArray());

var answer = wrong ? "No" : "Yes";
Console.WriteLine($"The word was: {input.ToLower()}");
Console.WriteLine($"Is the word spellable by the elements of the periodic table? {answer}");

bool TwoLetterMatch(string[] sequence, string check)
{
    return sequence.Any(s => s.Equals(check, StringComparison.OrdinalIgnoreCase));
}





// First try:

// for (int c = 0; c < chars.Length; c++)
// {
//     string? two;

//     if (c + 1 == chars.Length)
//     {
//         two = chars[c].ToString();
//     }
//     else
//     {
//         two = $"{chars[c]}{chars[c + 1]}";
//     }

//     foreach (var element in periodicTableElements)
//     {
//         if (element.Length == 2 && element.ToLower() == two)
//         {
//             match.Add(two);
//             c += 1;
//             continue;
//         }
//         else if (element.Length == 1 && element.ToLower() == chars[c].ToString())
//         {
//             match.Add(chars[c].ToString());
//             continue;
//         }
//     }

//     if (c + 1 == chars.Length)
//     {
//         break;
//     }
// }
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

Console.WriteLine("Write your iput:");
var input = Console.ReadLine();
var lower = input.ToLower();
var leetWord = new List<char>();

foreach (var letter in lower)
{
    string stringValue = letter.ToString();
    var value = 0;
    if (leetTable.TryGetValue(letter, out value))
    {
        stringValue = value.ToString();
    }

    leetWord.Add(stringValue[0]);

}

string word = new(leetWord.ToArray());

Console.WriteLine(word);

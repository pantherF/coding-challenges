using Solutions;

Console.WriteLine(PeriodicTableWords.CanSpell("nana"));
Console.WriteLine(LeetTranslator.Translate("string"));

var primeFactors = PrimeFactorization.PrimeFactors(34);

foreach (var factor in primeFactors)
{
    Console.WriteLine(factor);   
}

Console.WriteLine(RoundToNearestMultiple.Round(12, 5));

bool IsPrime(uint number)
{
    var numbers = new List<uint>();

    for (uint i = 1; i <= number; i++)
    {
        if (number % i == 0)
        {
            numbers.Add(i);
        }
    }

    if (numbers.Count == 2 && numbers.Contains(1) && numbers.Contains(number))
    {
        return true;
    }

    return false;
}

List<uint> Primes(uint until)
{
    List<uint> primes = [];

    for (uint i = 1; i <= until; i++)
    {
        if (IsPrime(i))
        {
            primes.Add(i);
        }
    }

    return [.. primes.OrderByDescending(n => n)];
}

List<uint> PrimeFactors(uint number)
{
    var primes = Primes(20);
    var factors = new List<uint>();

    Factor(number, primes, ref factors);

    return factors;
}

void Factor(uint number, List<uint> primes, ref List<uint> factors)
{
    foreach (var prime in primes)
    {
        Console.WriteLine($"-------------");
        Console.WriteLine($"#: {number}");

        Console.WriteLine($"prime: {prime}");

        Console.WriteLine($"# == prime: {number == prime}");

        Console.WriteLine($"# % prime: {number % prime}");

        Console.WriteLine($"# / prime: {number / prime}");
        Console.WriteLine($"-------------");

        if (number % prime == 0)
        {
            factors.Add(prime);

            Factor(number / prime, Primes(number / prime), ref factors);
            break;
        }
    }
}

var factors = PrimeFactors(42);
foreach (var factor in factors)
{
    Console.WriteLine(factor);
}

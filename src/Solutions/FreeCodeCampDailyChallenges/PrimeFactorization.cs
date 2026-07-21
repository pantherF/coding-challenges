namespace Solutions.FreeCodeCampDailyChallenges;

public static class PrimeFactorization
{
    private static bool IsPrime(uint number)
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

    private static List<uint> Primes(uint until)
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

    private static void Factor(uint number, List<uint> primes, ref List<uint> factors)
    {
        foreach (var prime in primes)
        {
            if (number % prime == 0)
            {
                factors.Add(prime);

                Factor(number / prime, Primes(number / prime), ref factors);
                break;
            }
        }
    }

    public static List<uint> PrimeFactors(uint number)
    {
        var primes = Primes(20);
        var factors = new List<uint>();

        Factor(number, primes, ref factors);

        factors.Sort();

        return factors;
    }

}

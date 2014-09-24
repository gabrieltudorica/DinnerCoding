using System.Collections.Generic;

namespace PrimeNumbers
{
    public class PrimeFactors
    {
        public static List<int> Generate(int number)
        {
            return number == 1 ? new List<int>() : GetPrimeFactorization(number);
        }

        private static List<int> GetPrimeFactorization(int number)
        {
            var primeFactors = new List<int>();

            for (int i = 2; i <= number; i++)
            {
                if (!TrialDivision.IsPrime(i)) continue;

                while (number % i == 0)
                {
                    number /= i;
                    primeFactors.Add(i);
                }
            }

            return primeFactors;
        }
    }
}

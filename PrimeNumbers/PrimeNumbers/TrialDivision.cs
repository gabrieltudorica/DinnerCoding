using System;

namespace PrimeNumbers
{
    public class TrialDivision
    {
        private const int FirstPrimeNumber = 2;

        public static bool IsPrime(int number)
        {
            if (number < FirstPrimeNumber)
            {
                return false;
            }

            for (int i = FirstPrimeNumber; i <= GetMaximumDivisor(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static int GetMaximumDivisor(int number)
        {
            return Convert.ToInt32(Math.Sqrt(number));
        }
    }
}

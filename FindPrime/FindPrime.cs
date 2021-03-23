using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindPrime
{
    class FindPrime
    {
        public static Task<bool> isPrime(int target)
        {
            return Task.Run(() =>
            {
                if (target < 0) return false;
                if (target == 0 || target == 1) return false;
                for (int i = 2; i <= target - 1; i++)
                {
                    if (target % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            );
        }
        public static async Task<List<int>> returnPrimeNumbers(int headRange, int tailRange)
        {
            List<int> primeNumbers = new List<int>();
            for (int i = headRange; i <= tailRange; i++)
            {
                if (await isPrime(i))
                {
                    primeNumbers.Add(i);
                }
            }

            return primeNumbers;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindPrime
{
    class Program
    {
        public static bool isPrime(int target)
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
        public static List<int> returnPrimeNumbers(int minRange, int maxRange)
        {
            List<int> primeNumbers = new List<int>();
            bool result;
            for (int i = minRange; i <= maxRange; i++)
            {
                result = isPrime(i);
                if (result)
                {
                    primeNumbers.Add(i);
                }
            }

            return primeNumbers;
        }


        public static void Main(string[] args)
        {
            Console.WriteLine("Min Range:");
            int minRange = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Max Range:");
            int maxRange = Int32.Parse(Console.ReadLine());
            List<int> primeNumbers = returnPrimeNumbers(minRange, maxRange);
            foreach (var primeNumber in primeNumbers)
            {
                Console.Write("\t" + primeNumber);
            }
        }
    }
}


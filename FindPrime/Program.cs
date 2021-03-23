using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindPrime
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Min Range:");
            int minRange = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Max Range:");
            int maxRange = Int32.Parse(Console.ReadLine());
            PrintPrimeNumbersList(await FindPrime.returnPrimeNumbers(minRange, maxRange));

        }
        public static void PrintPrimeNumbersList(List<int> primeNumbers)
        {
            foreach (var primeNumber in primeNumbers)
            {
                Console.Write("\t" + primeNumber);
            }
        }
    }
}


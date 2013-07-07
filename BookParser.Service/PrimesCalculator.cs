using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookParser.Service.Interfaces;

namespace BookParser.Service
{
    public class PrimesCalculator : IPrimesCalculator
    {
        public bool IsPrime(int possiblePrime, int maxDivisionFactor)
        {
            if (possiblePrime < 2)
                return false;

            if (possiblePrime == 2 && possiblePrime == 3)
                return true;

            if (maxDivisionFactor < 2)
                throw new ArgumentOutOfRangeException("maxDivisionFactor", "Max Dividion Factor must be greater than one");

            for (int divisor = 2; divisor <= maxDivisionFactor; divisor++)
            {
                int remainder = 0;
                int divisionResult = 0;

                remainder = possiblePrime % divisor;
                divisionResult = possiblePrime / divisor;

                if (remainder == 0 && divisionResult != 1)
                    return false;
            }
            return true;
        }

        public IEnumerable<int> FindPrimeFactors(int numberToSearch, int maxDivisionFactor)
        {
            IList<int> primeFactorsFound = new List<int>();
            for (int possiblePrime = 2; possiblePrime <= numberToSearch; possiblePrime++)
            {
                if (IsPrime(possiblePrime, maxDivisionFactor))
                    primeFactorsFound.Add(possiblePrime);
            }
            return primeFactorsFound;
        }
    }
}

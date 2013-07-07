using System;
using System.Collections.Generic;
using System.Linq;
using BookParser.Service.Interfaces;

namespace BookParser.Service
{
    public class PrimesCache
    {
        private IEnumerable<int> _primes;
        private readonly IPrimesCalculator _primesCalculator;

        public PrimesCache(IPrimesCalculator primesCalculator)
        {
            if (primesCalculator == null)
                throw new ArgumentNullException("primesCalculator");

            _primesCalculator = primesCalculator;
        }

        public void GetPrimeFactors(IDictionary<string, int> wordsWithCount)
        {
            int maxValue = wordsWithCount.Values.Max();
            int maxDivisionFactor = (int)Math.Sqrt(maxValue);
            _primes = _primesCalculator.FindPrimeFactors(maxValue, maxDivisionFactor);
        }

        public bool IsPrime(int primeCandidate)
        {
            if (_primes == null)
                throw new NullReferenceException("PrimesCache has not been populated. Please call GetPrimeFactors");

            return _primes.Contains(primeCandidate);
        }

        public IEnumerable<int> PrimesCached { get { return _primes; } }
    }
}

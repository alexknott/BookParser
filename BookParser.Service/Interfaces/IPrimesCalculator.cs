using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookParser.Service.Interfaces
{
    public interface IPrimesCalculator
    {
        bool IsPrime(int possiblePrime, int maxDivisionFactor);
        IEnumerable<int> FindPrimeFactors(int numberToSearch, int maxDivisionFactor);
    }
}

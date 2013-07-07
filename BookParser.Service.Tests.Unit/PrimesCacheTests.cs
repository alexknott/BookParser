using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookParser.Service.Interfaces;
using BookParser.Service;
using NUnit.Framework;
using Moq;

namespace BookParser.Service.Tests.Unit
{
    [TestFixture]
    public class PrimesCacheTests
    {
        [Test]
        public void When_Constructor_Parameter_PrimesCalculator_Is_Null_Throws()
        {
            TestDelegate testDelegate = () => new PrimesCache(null);
            var ex = Assert.Throws<ArgumentNullException>(testDelegate);
            Assert.AreEqual("primesCalculator", ex.ParamName);
        }

        [Test]
        public void Verfiy_GetPrimeFactors_Calls_Dependancies()
        {
            var primesCalculatorMock = new Mock<IPrimesCalculator>();
            var primesFake = new List<int>();
            primesFake.Add(2);
            primesFake.Add(3);
            primesFake.Add(5);
            primesFake.Add(7);
            
            primesCalculatorMock.Setup(m => m.FindPrimeFactors(10, 3)).Returns(primesFake);
            
            var primesCache = new PrimesCache(primesCalculatorMock.Object);


            IDictionary<string, int> testInput = new Dictionary<string, int>();
            testInput.Add(new KeyValuePair<string,int>("word", 10));
            testInput.Add(new KeyValuePair<string,int>("another", 4));
            TestDelegate testDelegate = () => primesCache.GetPrimeFactors(testInput);
            Assert.DoesNotThrow(testDelegate);
            primesCalculatorMock.Verify(m => m.FindPrimeFactors(10, 3), Times.Once());
            Assert.AreEqual(4, primesCache.PrimesCached.Count());
        }

        [Test]
        public void IsPrime_Throws_Exception_When_Cache_Has_Not_Been_Populated()
        {
            var primesCalculatorMock = new Mock<IPrimesCalculator>();
            var primesCache = new PrimesCache(primesCalculatorMock.Object);

            TestDelegate testDelegate = () => primesCache.IsPrime(4);
            var ex = Assert.Throws<NullReferenceException>(testDelegate);
            Assert.AreEqual("PrimesCache has not been populated. Please call GetPrimeFactors", ex.Message);
        }

        [Test]
        public void IsPrime_Correctly_Identifies_Primes()
        {
            var primesCalculatorMock = new Mock<IPrimesCalculator>();
            var primesFake = new List<int>();
            primesFake.Add(2);
            primesFake.Add(3);
            primesFake.Add(5);
            primesFake.Add(7);

            primesCalculatorMock.Setup(m => m.FindPrimeFactors(10, 3)).Returns(primesFake);

            IDictionary<string, int> testInput = new Dictionary<string, int>();
            testInput.Add(new KeyValuePair<string,int>("word", 10));
            testInput.Add(new KeyValuePair<string,int>("another", 4));
            var primesCache = new PrimesCache(primesCalculatorMock.Object);
            primesCache.GetPrimeFactors(testInput);

            Assert.IsTrue(primesCache.IsPrime(2));
            Assert.IsTrue(primesCache.IsPrime(3));
            Assert.IsTrue(primesCache.IsPrime(5));
            Assert.IsTrue(primesCache.IsPrime(7));

            Assert.IsFalse(primesCache.IsPrime(1));
            Assert.IsFalse(primesCache.IsPrime(4));
            Assert.IsFalse(primesCache.IsPrime(6));
            Assert.IsFalse(primesCache.IsPrime(8));
            Assert.IsFalse(primesCache.IsPrime(9));
            Assert.IsFalse(primesCache.IsPrime(10));
        }
    }
}

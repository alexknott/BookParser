using System;
using System.Collections.Generic;
using System.Linq;
using BookParser.Service.Interfaces;
using BookParser.Service;
using NUnit.Framework;
using Moq;

namespace BookParser.Service.Tests.Unit
{


    [TestFixture]
    public class PrimesCalculatorTests
    {
        private IPrimesCalculator _primesCalculator;

        [SetUp]
        public void SetUp()
        {
            _primesCalculator = new PrimesCalculator();
        }

        [Test]
        public void IsPrimeShouldReturnFalseForNumbersThatAreNotPrime()
        {
            Assert.IsFalse(_primesCalculator.IsPrime(1, 1));
            Assert.IsFalse(_primesCalculator.IsPrime(4, 4));
            Assert.IsFalse(_primesCalculator.IsPrime(6, 6));
            Assert.IsFalse(_primesCalculator.IsPrime(8, 8));
            Assert.IsFalse(_primesCalculator.IsPrime(9, 9));
        }

        [Test]
        public void IsPrimeShouldReturnTrueForNumbersThatArePrime()
        {
            Assert.IsTrue(_primesCalculator.IsPrime(2, 2));
            Assert.IsTrue(_primesCalculator.IsPrime(3, 3));
            Assert.IsTrue(_primesCalculator.IsPrime(5, 5));
            Assert.IsTrue(_primesCalculator.IsPrime(7, 7));
            Assert.IsTrue(_primesCalculator.IsPrime(967, 967));
        }

        [Test]
        public void IsPrimeShouldThrowDivideByZeroException()
        {
            TestDelegate testDelegate = () => _primesCalculator.IsPrime(4, 0);
            Assert.Throws(typeof(ArgumentOutOfRangeException), testDelegate);
        }

        [Test]
        public void FindPrimeFactorsShouldReturnPrimeFactors()
        {
            var primeFactors = _primesCalculator.FindPrimeFactors(0, 0);
            Assert.IsEmpty(primeFactors);
            primeFactors = _primesCalculator.FindPrimeFactors(1, 1);
            Assert.IsEmpty(primeFactors);
            primeFactors = _primesCalculator.FindPrimeFactors(2, 2);
            Assert.AreEqual(primeFactors.Count(), 1);
            Assert.AreEqual(primeFactors.ToArray()[0], 2);
            primeFactors = _primesCalculator.FindPrimeFactors(3, 3);
            Assert.AreEqual(primeFactors.Count(), 2);
            Assert.AreEqual(primeFactors.ToArray()[1], 3);
            primeFactors = _primesCalculator.FindPrimeFactors(3, 3);
            Assert.AreEqual(primeFactors.Count(), 2);
            Assert.AreEqual(primeFactors.ToArray()[1], 3);
            primeFactors = _primesCalculator.FindPrimeFactors(100, 10);
            Assert.AreEqual(primeFactors.Count(), 25);
            Assert.AreEqual(primeFactors.ToArray()[24], 97);
        }
    }
}

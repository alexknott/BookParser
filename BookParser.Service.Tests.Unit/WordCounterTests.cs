using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BookParser.Service.Tests.Unit
{
    [TestFixture]
    public class WordCounterTests
    {
        private WordCounter _wordCounter;

        [SetUp]
        public void TestSetUp()
        {
            _wordCounter = new WordCounter();
        }

        [Test]
        public void When_No_Words_GetWordsDictionaryWithCount_Returns_An_Empty_Dictionary() 
        {
            var result = _wordCounter.GetWordsDictionaryWithCount(new List<string>());
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void When_One_Word_It_Is_Returned_With_Count()
        {
            var wordListInput = new List<string>();
            wordListInput.Add("word");

            var result = _wordCounter.GetWordsDictionaryWithCount(wordListInput);

            Assert.AreEqual(1, result.Count);
            Assert.IsNotNull(result["word"]);
            Assert.AreEqual(1, result["word"]);
        }

        [Test]
        public void When_All_Words_The_Same_One_Word_Is_Returned_With_Count()
        {
            var wordListInput = new List<string>();
            wordListInput.Add("word");
            wordListInput.Add("word");
            wordListInput.Add("word");
            wordListInput.Add("word");

            var result = _wordCounter.GetWordsDictionaryWithCount(wordListInput);

            Assert.AreEqual(1, result.Count);
            Assert.IsNotNull(result["word"]);
            Assert.AreEqual(4, result["word"]);
        }

        [Test]
        public void When_Serveral_Words_They_Are_Returned_With_Count()
        {
            var wordListInput = new List<string>();
            wordListInput.Add("word");
            wordListInput.Add("word");
            wordListInput.Add("word");
            wordListInput.Add("another");
            wordListInput.Add("Another");
            wordListInput.Add("tennis");

            var result = _wordCounter.GetWordsDictionaryWithCount(wordListInput);

            Assert.AreEqual(3, result.Count);
            Assert.IsNotNull(result["word"]);
            Assert.AreEqual(3, result["word"]);

            Assert.IsNotNull(result["another"]);
            Assert.AreEqual(2, result["another"]);

            Assert.IsNotNull(result["tennis"]);
            Assert.AreEqual(1, result["tennis"]);
        }
    }
}


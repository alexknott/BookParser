using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Moq.Proxy;
using BookParser.Service.Interfaces;

namespace BookParser.Service.Tests.Unit
{
    [TestFixture]
    public class BookParserServiceGetWordsWithCountTests
    {
        private Mock<IBookDataAccess> _bookDataAccessMock;
        private Mock<IWordCounter> _wordCounterMock;

        [SetUp]
        public void SetUp()
        {
            _bookDataAccessMock = new Mock<IBookDataAccess>();
            _wordCounterMock = new Mock<IWordCounter>();
        }

        [Test]
        public void When_No_Words_Should_Return_An_Empty_Collection()
        {
            _wordCounterMock.Setup(m => m.GetWordsDictionaryWithCount(It.IsAny<IEnumerable<string>>())).Returns(new Dictionary<string, int>());

            BookParserService bookParserService = new BookParserService(_bookDataAccessMock.Object, _wordCounterMock.Object);
            IEnumerable<string> wordsWithCount = bookParserService.GetWordsWithWordCount();
            
            Assert.IsNotNull(wordsWithCount);
        }

        [Test]
        public void Words_Should_Be_Returned_With_Count()
        {
            IDictionary<string, int> wordstWithCountFake = new Dictionary<string, int>();        
            wordstWithCountFake.Add(new KeyValuePair<string,int>("Word", 10));
            wordstWithCountFake.Add(new KeyValuePair<string, int>("Another", 3));
            wordstWithCountFake.Add(new KeyValuePair<string, int>("Test", 5));
            wordstWithCountFake.Add(new KeyValuePair<string, int>("Sample", 100));

            _wordCounterMock.Setup(m => m.GetWordsDictionaryWithCount(It.IsAny<IEnumerable<string>>())).Returns(wordstWithCountFake);
         
            var bookParserService = new BookParserService(_bookDataAccessMock.Object, _wordCounterMock.Object);
            IEnumerable<string> wordsWithCount = bookParserService.GetWordsWithWordCount();

            _bookDataAccessMock.Verify(m => m.GetWordsFromSource(), Times.Once());
            _wordCounterMock.Verify(m => m.GetWordsDictionaryWithCount(It.IsAny<IEnumerable<string>>()), Times.Once());
            
            var results = wordsWithCount.ToArray();
            Assert.AreEqual(4, results.Length);
            Assert.AreEqual("Word 10", results[0]);
            Assert.AreEqual("Another 3", results[1]);
            Assert.AreEqual("Test 5", results[2]);
            Assert.AreEqual("Sample 100", results[3]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using BookParser.Service.Interfaces;
using System.IO;
using System.Reflection;

namespace BookParser.Service.Tests.Unit
{
    [TestFixture]
    public class BookDataAccessTests
    {
        [Test]
        public void When_Constructor_Parameter_StreamProvider_Is_Null_Exception_Is_Thrown()
        {
            TestDelegate testDelegate = () => new BookDataAccess(null, null);
            var ex = Assert.Throws<ArgumentNullException>(testDelegate);
            Assert.AreEqual("streamProvider", ex.ParamName);
        }
        
        [Test]
        public void When_No_Words_GetWordsFromSource_Returns_An_Empty_List()
        {
            var streamProviderMock = new Mock<IStreamProvider>();
            streamProviderMock.Setup(m => m.GetStreamReaderFromManifestResource(It.IsAny<string>())).Returns(GetMockStream("BookParser.Service.Tests.Unit.TestResources.Empty.txt"));

            var lineParserMock = new Mock<ILineParser>();

            BookDataAccess bookDataAccess = new BookDataAccess(streamProviderMock.Object, lineParserMock.Object);
            var results = bookDataAccess.GetWordsFromSource();

            Assert.IsNotNull(results);
            Assert.IsFalse(results.Any());
        }

        [Test]
        public void GetWordsFromSource_Should_Return_The_Words()
        {
            var streamProviderMock = new Mock<IStreamProvider>();
            streamProviderMock.Setup(m => m.GetStreamReaderFromManifestResource("BookParser.Service.Resources.book_DEVOTA.txt")).Returns(GetMockStream("BookParser.Service.Tests.Unit.TestResources.TestBook.txt"));

            var lineParserMock = new Mock<ILineParser>();

            BookDataAccess bookDataAccess = new BookDataAccess(streamProviderMock.Object, new LineParser());
            var results = bookDataAccess.GetWordsFromSource();

            Assert.IsNotNull(results);
            Assert.AreEqual(17, results.Count());
        }

        private StreamReader GetMockStream(string resourceName)
        {
            var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            return new StreamReader(resourceStream);
        }


    }
}

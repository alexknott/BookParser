using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using BookParser.Service.Interfaces;

namespace BookParser.Service.Tests.Unit
{
    [TestFixture]
    public class BookParserServiceConstructorTests
    {
        [Test]
        public void When_Null_Constructor_Parameter_BookDataAccess_Exception_Is_Thrown()
        {
            TestDelegate testDelegate = () => new BookParserService(null, null);
            Assert.Throws<ArgumentNullException>(testDelegate, "BookDataAccess can not be null");
        }

        [Test]
        public void When_Null_Constructor_Parameter_WordCounter_Exception_Is_Thrown()
        {
            var bookDataAccessMock = new Mock<IBookDataAccess>();
            TestDelegate testDelegate = () => new BookParserService(bookDataAccessMock.Object, null);
                        
            Assert.Throws<ArgumentNullException>(testDelegate, "WordCounter can not be null");
        }
    }
}

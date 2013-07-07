using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using NUnit.Framework;
using Ninject.MockingKernel.Moq;
using Moq;
using FluentAssertions;
using BookParser.ConsoleApplication;
using BookParser.Service.Interfaces;
using ConsoleApplication.Library.Interfaces;

namespace BookParser.ConsoleApplication.Tests.Unit
{
    [TestFixture]
    public class BookParserConsoleApplicationTests
    {
        [Test]
        public void When_Constructor_Parameter_Kernel_Is_Null_Exception_Is_Thrown()
        {
            //USING NUunit
            TestDelegate testDelegate = () => new BookParserConsoleApplication(null);
            var ex  = Assert.Throws<ArgumentNullException>(testDelegate);
            Assert.AreEqual("kernel", ex.ParamName);
            
            //USING NUnit AND FluentAssertions (better in my opinion!)
            Action action = () => new BookParserConsoleApplication(null);
            action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("kernel");
        }

        [Test]
        public void When_Constructor_Parameters_Are_Valid_No_Exception_Is_Thrown()
        {
            var kernelMoq = new MoqMockingKernel();
            Action action = () => new BookParserConsoleApplication(kernelMoq);
            action.ShouldNotThrow("Valid parameters should of been passed to the constructor");
        }

        [Test]
        public void Verify_ParseBook_Calls_The_Correct_Methods_On_Its_Dependencies()
        {
            var kernelMoq = new MoqMockingKernel();
            var bookParserServiceMock = kernelMoq.GetMock<IBookParserService>();
            var consoleFacadeMock = kernelMoq.GetMock<IConsoleFacade>();

            var wordsWithCountFake = new List<string>();
            wordsWithCountFake.Add("Dog 1");
            wordsWithCountFake.Add("Rabbit 3");
            wordsWithCountFake.Add("Chicken 12");
            wordsWithCountFake.Add("Pig 3");
            bookParserServiceMock.Setup(m => m.GetWordsWithWordCount()).Returns(wordsWithCountFake);


            var bookParserConsoleApplication = new BookParserConsoleApplication(kernelMoq);
            bookParserConsoleApplication.ParseBook();

            bookParserServiceMock.Verify(m => m.GetWordsWithWordCount(), Times.Once());
            consoleFacadeMock.Verify(m => m.WriteLine(It.IsAny<string>()), Times.Exactly(6));
            consoleFacadeMock.Verify(m => m.WriteLine(wordsWithCountFake[0]), Times.Once());
            consoleFacadeMock.Verify(m => m.WriteLine(wordsWithCountFake[1]), Times.Once());
            consoleFacadeMock.Verify(m => m.WriteLine(wordsWithCountFake[2]), Times.Once());
            consoleFacadeMock.Verify(m => m.WriteLine(wordsWithCountFake[3]), Times.Once());

            consoleFacadeMock.Verify(m => m.ReadKey(), Times.Exactly(3));
        }
    }
}

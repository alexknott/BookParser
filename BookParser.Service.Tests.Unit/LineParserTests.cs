using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BookParser.Service.Interfaces;
using BookParser.Service;

namespace BookParser.Service.Tests.Unit
{
    [TestFixture]
    public class LineParserTests
    {
        [Test]
        public void CleanLine_Should_Remove_All_Non_Alpha_Chars_Except_Whitespace()
        {
            string testLine = "some, test *** data @ with ''' ~ # some punctuation etc";
            var lineParser = new LineParser();
            var result = lineParser.CleanLine(testLine);

            Assert.AreEqual("some test  data  with    some punctuation etc", result);
        }

        [Test]
        public void SplitLine_Should_Split_On_Whitespace()
        {
            string testLine = "some test  data  with    some punctuation etc";
            var lineParser = new LineParser();
            var result = lineParser.SplitLine(testLine);
            Assert.AreEqual(7, result.Count());
        }
    }
}

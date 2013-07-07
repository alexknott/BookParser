using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;


namespace ConsoleApplication.Library.Tests.Unit
{
    [TestFixture]
    public class ConsoleFacadeTests
    {
        [Test]
        public void WriteLine_Should_Write_To_The_Console() 
        {
            string expectedOutput = "TheExpectedOutput";
            
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                var consoleFacade = new ConsoleFacade();

                consoleFacade.WriteLine(expectedOutput);

                expectedOutput = string.Concat(expectedOutput, Environment.NewLine);
                Assert.AreEqual(expectedOutput, stringWriter.ToString());
            }
        }
    }
}

using System;
using NUnit.Framework;


namespace BookParser.Service.Tests.Unit
{
    [TestFixture]
    public class StreamProviderTests
    {
        [Test]
        public void When_Resource_Parameter_Is_Empty_Exception_Is_Thrown()
        {
            StreamProvider streamProvider = new StreamProvider();
            TestDelegate testDelegate = () => streamProvider.GetStreamReaderFromManifestResource(string.Empty);
            var ex = Assert.Throws<ArgumentNullException>(testDelegate, "Null resource name is not allowed");
            Assert.AreEqual("resourceName", ex.ParamName);
        }

        [Test]
        public void When_Resource_Invalid_GetStreamReaderFromManifestResource_Should_Throw()
        {
            string resourceName = "invalidResourceName";
            StreamProvider streamProvider = new StreamProvider();
            TestDelegate testDelegate = () => streamProvider.GetStreamReaderFromManifestResource(resourceName);
            Assert.Throws<NullReferenceException>(testDelegate, "exception should be thrown when resource is not found"); 
        }

        [Test]
        public void When_Valid_Resource_Should_Return_The_Stream()
        {
            string resourceName = "BookParser.Service.Resources.book_DEVOTA.txt";
            StreamProvider streamProvider = new StreamProvider();
            var stream = streamProvider.GetStreamReaderFromManifestResource(resourceName);

            Assert.AreEqual(98888, stream.ReadToEnd().Length);
        }
    }
}

using System;
using System.IO;
using System.Reflection;
using BookParser.Service.Interfaces;

namespace BookParser.Service
{
    public class StreamProvider : IStreamProvider
    {
        public StreamReader GetStreamReaderFromManifestResource(string resourceName)
        {
            if (string.IsNullOrWhiteSpace(resourceName))
                throw new ArgumentNullException("resourceName", "resourceName must be supplied");

            var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            if (resourceStream == null)
                throw new NullReferenceException(string.Format("Resource: {0} - could not be found in the Manifest", resourceName));
            return new StreamReader(resourceStream);
        }
    }
}

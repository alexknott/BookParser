using System.IO;

namespace BookParser.Service.Interfaces
{
    public interface IStreamProvider
    {
        StreamReader GetStreamReaderFromManifestResource(string resourceName);
    }
}

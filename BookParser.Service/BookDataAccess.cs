using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookParser.Service.Interfaces;
using System.IO;
using System.Reflection;

namespace BookParser.Service
{
    public class BookDataAccess : IBookDataAccess
    {
        private const string RESOURCE_FILE_NAME = "BookParser.Service.Resources.book_DEVOTA.txt";
        private readonly IStreamProvider _streamProvider;
        private readonly ILineParser _lineParser;

        public BookDataAccess(IStreamProvider streamProvider, ILineParser lineParser)
        {
            if (streamProvider == null)
                throw new ArgumentNullException("streamProvider");

            if (lineParser == null)
                throw new ArgumentNullException("lineParser");

            _streamProvider = streamProvider;
            _lineParser = lineParser;
        }

        public IEnumerable<string> GetWordsFromSource()
        {
            List<string> results = new List<string>();
            var lines = GetLinesFromResource();

            if (lines == null || !lines.Any())
                return results;
                                 
            foreach (var line in lines)
                results.AddRange(ParseWords(line));
            
            return results;
        }

        private IEnumerable<string> ParseWords(string line)
        {
            var cleanLine = _lineParser.CleanLine(line);
            return _lineParser.SplitLine(cleanLine);
        }

        private IList<string> GetLinesFromResource()
        {
            var lines = new List<string>();
            var reader = _streamProvider.GetStreamReaderFromManifestResource(RESOURCE_FILE_NAME);
            while (!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }

            return lines;
        }
    }
}

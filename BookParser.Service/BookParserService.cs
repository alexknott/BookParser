using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BookParser.Service.Interfaces;

namespace BookParser.Service
{
    public class BookParserService : IBookParserService
    {
        private IBookDataAccess _bookDataAccess;
        private IWordCounter _wordCounter;
        private Lazy<IDictionary<string, int>> wordsWithCount;
        
        public BookParserService(IBookDataAccess bookDataAccess, IWordCounter wordCounter)
        {
            if (bookDataAccess == null)
                throw new ArgumentNullException("bookDataAccess", "BookDataAccess can not be null");
            if (wordCounter == null)
                throw new ArgumentNullException("wordCounter", "WordCounter can not be null");

            _bookDataAccess = bookDataAccess;
            _wordCounter = wordCounter;
            wordsWithCount = new Lazy<IDictionary<string,int>>(GetWordsWithCount); 

        }

        public IEnumerable<string> GetWordsWithWordCount()
        {
            IList<string> results = new List<string>();

            //int maxValue = wordsWithCount.Value.Values.Max();

            foreach (var keyValue in wordsWithCount.Value)
                results.Add(string.Concat(keyValue.Key, " ", keyValue.Value));
            
            return results;
        }

        private IDictionary<string, int> GetWordsWithCount()
        {
            return _wordCounter.GetWordsDictionaryWithCount(_bookDataAccess.GetWordsFromSource());  
        }
    }
}

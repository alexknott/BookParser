using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using BookParser.Service.Interfaces;

namespace BookParser.Service
{
    public class WordCounter : IWordCounter
    {
        public IDictionary<string, int> GetWordsDictionaryWithCount(IEnumerable<string> words)
        {
            IDictionary<string, int> results = new Dictionary<string, int>();

            if (words == null || !words.Any())
                return results;

            var distinctList = words.Distinct<string>(StringComparer.InvariantCultureIgnoreCase);
            foreach (var distinct in distinctList)
            {
                int count = words.Where(w => string.Equals(w, distinct, StringComparison.InvariantCultureIgnoreCase)).Count();
                results.Add(new KeyValuePair<string, int>(distinct.ToLower(), count));
            }

            return results;
        }
    }
}

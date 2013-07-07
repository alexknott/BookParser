using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookParser.Service.Interfaces
{
    public interface IWordCounter
    {
        IDictionary<string, int> GetWordsDictionaryWithCount(IEnumerable<string> enumerable);
    }
}

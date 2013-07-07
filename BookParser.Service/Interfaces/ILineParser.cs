using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookParser.Service.Interfaces
{
    public interface ILineParser
    {
        string CleanLine(string line);
        IEnumerable<string> SplitLine(string line);
    }
}

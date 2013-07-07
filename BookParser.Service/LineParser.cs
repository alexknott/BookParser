using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BookParser.Service.Interfaces;

namespace BookParser.Service
{
    public class LineParser : ILineParser
    {
        public string CleanLine(string line)
        {
            Regex regx = new Regex("[^a-zA-Z0-9 ]");
            return regx.Replace(line, string.Empty);
        }

        public IEnumerable<string> SplitLine(string line)
        {
            return line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}

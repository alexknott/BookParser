using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Library.Interfaces
{
    public interface IConsoleFacade
    {
        void WriteLine(string data);
        void ReadKey();
    }
}

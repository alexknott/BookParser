using System;
using ConsoleApplication.Library.Interfaces;

namespace ConsoleApplication.Library
{
    public class ConsoleFacade : IConsoleFacade
    {
        public void WriteLine(string data)
        {
            Console.WriteLine(data);
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }
    }
}

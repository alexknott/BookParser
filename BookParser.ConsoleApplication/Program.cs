using System;
using System.Collections.Generic;
using Ninject;
using BookParser.Service;
using BookParser.Service.Interfaces;
using BookParser.Service.NinjectModules;

namespace BookParser.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new ApplicationBindingsModule());
            var bookParserConsoleApplication = new BookParserConsoleApplication(kernel);
            bookParserConsoleApplication.ParseBook();
        }
    }
}

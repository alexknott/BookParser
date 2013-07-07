using System;
using System.Collections.Generic;
using BookParser.Service.Interfaces;
using ConsoleApplication.Library.Interfaces;
using Ninject;

namespace BookParser.ConsoleApplication
{
    public class BookParserConsoleApplication
    {
        private IBookParserService _bookParserService;
        private IConsoleFacade _consoleFacade;

        public BookParserConsoleApplication(IKernel kernel)
        {
            if (kernel == null)
                throw new ArgumentNullException("kernel", "Constructor parameter \"kernel\" can not be null");

            _bookParserService = kernel.Get<IBookParserService>();
            _consoleFacade = kernel.Get<IConsoleFacade>();
        }

        public void ParseBook()
        {         
            _consoleFacade.WriteLine("Calculating....");

            var wordsWithCount = _bookParserService.GetWordsWithWordCount();
            
            DisplayScrollableResults(wordsWithCount);

            DisplayFinishedMessage();
        }

        private void DisplayScrollableResults(IEnumerable<string> wordsWithCount)
        {
            int count = 0;
            foreach (var word in wordsWithCount)
            {
                _consoleFacade.WriteLine(word);
                count++;

                if (count == 297)
                {
                    count = 0;
                    _consoleFacade.WriteLine("Press any key to continue displaying results...");
                    _consoleFacade.ReadKey();
                }
            }
        }

        private void DisplayFinishedMessage()
        {
            _consoleFacade.WriteLine("PRESS THREE TIMES TO EXIT");
         
            for(int i=0; i<3; i++)           
                _consoleFacade.ReadKey();
        }
    }
}

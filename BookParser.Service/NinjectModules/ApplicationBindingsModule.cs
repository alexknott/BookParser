using BookParser.Service.Interfaces;
using ConsoleApplication.Library.Interfaces;
using ConsoleApplication.Library;
using Ninject;
using Ninject.Modules;

namespace BookParser.Service.NinjectModules
{
    public class ApplicationBindingsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookParserService>().To<BookParserService>();
            Bind<IConsoleFacade>().To<ConsoleFacade>();
            Bind<IBookDataAccess>().To<BookDataAccess>();
            Bind<IWordCounter>().To<WordCounter>();
            Bind<IStreamProvider>().To<StreamProvider>();
            Bind<ILineParser>().To<LineParser>();
        }
    }
}

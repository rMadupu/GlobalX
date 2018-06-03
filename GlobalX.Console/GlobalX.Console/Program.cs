using System.Collections.Generic;
using System.Linq;
using GlobalX.Library;
using GlobalX.Library.Interfaces;
using GlobalX.Library.Model;
using SimpleInjector;

namespace GlobalX.Console
{
    class Program
    {
        private static readonly Container Container = new Container();

        static void Main(string[] args)
        {
            var path = string.Empty;
            if (args.Length == 0)
            {
                System.Console.Write("Please provide the unsorted names list file path: ");
                path = System.Console.ReadLine();
            }
            else
            {
                path = args[0];
            }

            RegisterModules(path);

            var app = new App(Container.GetInstance<IReader<Person>>(), 
                Container.GetInstance<IWriter<Person>>(), 
                Container.GetInstance< ISorter<IEnumerable<Person>, IOrderedEnumerable<Person>>>());
            app.Run(out var sortedList);
            sortedList.ForEach(System.Console.WriteLine);
            System.Console.Read();
        }
        /// <summary>
        /// Used SimpleInjector
        /// </summary>
        /// <param name="path"></param>
        private static void RegisterModules(string path)
        {
            Container.Options.DefaultLifestyle = Lifestyle.Singleton;
            Container.Register<IReader<Person>>(() => new FileReader(path));
            Container.Register<IWriter<Person>>(() => new FileWriter("sorted-names-list.txt"));
            Container.Register<ISorter<IEnumerable<Person>, IOrderedEnumerable<Person>>, Sorter>();
        }
    }
}
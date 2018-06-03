using System.Collections.Generic;
using System.Linq;
using GlobalX.Library;
using GlobalX.Library.Interfaces;
using GlobalX.Library.Model;

namespace GlobalX.Console
{
    public class App
    {
        public IReader<Person> Reader { get; }
        public IWriter<Person> Writer { get; }
        public ISorter<IEnumerable<Person>, IOrderedEnumerable<Person>> Sorter { get; }

        public App(IReader<Person> reader, IWriter<Person> writer, ISorter<IEnumerable<Person>, IOrderedEnumerable<Person>> sorter)
        {
            Reader = reader;
            Writer = writer;
            Sorter = sorter;
        }

        public bool Run(out List<string> sortedList)
        {
            sortedList = new List<string>();
            if (!Reader.Load()) return false;
            if (Reader.IsFileEmpty()) return false;
            var unSortedPeople = Reader.Map();
            var sortedPeople =  Sorter.Sort(unSortedPeople);
            Writer.Store(sortedPeople);
            sortedList.AddRange(sortedPeople.Select(x=>x.FullName));
            return true;
        }

    }
}
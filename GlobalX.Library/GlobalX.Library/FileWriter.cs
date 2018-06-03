using System.IO;
using System.Linq;
using GlobalX.Library.Interfaces;
using GlobalX.Library.Model;

namespace GlobalX.Library
{
    public class FileWriter : IWriter<Person>
    {
        private readonly string _filePath;

        public FileWriter(string filePath)
        {
            _filePath = filePath;
        }
        
        public void Store(IOrderedEnumerable<Person> sortedPeople)
        {
            File.WriteAllLines(_filePath, sortedPeople.Select(x => x.FullName));
        }
    }
}
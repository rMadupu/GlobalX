using System.Collections.Generic;
using System.IO;
using System.Linq;
using GlobalX.Library.Interfaces;
using GlobalX.Library.Model;

namespace GlobalX.Library
{
    public class FileReader : IReader<Person>
    {
        private readonly string _filePath;
        private List<string> _fileContents;

        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        public bool Load()
        {
            if (!File.Exists(_filePath)) return false;

            _fileContents = File.ReadAllLines(_filePath).ToList();

            return true;
        }

        public IEnumerable<Person> Map()
        {
            // Assumption: If only one name is given, we treat as last name
            var people = _fileContents.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x =>
            {
                var data = x.Split(' ');
                var person = new Person
                {
                    LastName = data.Last(),
                    FirstName = data.Length > 1 ? string.Join(" ", data.Take(data.Length - 1)).Trim() : ""
                };
                return person;
            });

            return people;
        }

        public bool IsFileEmpty()
        {
            return !_fileContents.Any();
        }

    }
}
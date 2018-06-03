using System.Collections.Generic;
using System.IO;
using System.Linq;
using GlobalX.Console;
using GlobalX.Library;
using GlobalX.Library.Model;
using Xunit;

namespace GlobalX.UnitTests
{
    public class FileWriterTests
    {
        private readonly string _sortedFileNamePath;

        public FileWriterTests()
        {
            _sortedFileNamePath = "filewriter.txt";
        }

        [Fact]
        public void GivenAnOrderedListItShouldWriteToFile()
        {
            //Arrange

            var app = new FileWriter(_sortedFileNamePath);

            //Act
            var people = new List<Person> {new Person {FirstName = "Raveendra", LastName = "Madupu"}};
            app.Store(people.OrderBy(x=>x.LastName).ThenBy(x=>x.FirstName));

            var sortedFileContent = File.ReadAllLines(_sortedFileNamePath);

            //Assert
            Assert.True(File.Exists(_sortedFileNamePath));
            Assert.Equal(people.Count, sortedFileContent.Length);
            Assert.Equal("Raveendra Madupu", sortedFileContent.ToList().First());
        }
    }
}
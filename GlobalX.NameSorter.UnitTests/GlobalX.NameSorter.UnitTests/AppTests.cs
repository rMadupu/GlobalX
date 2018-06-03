using GlobalX.Library;
using System.IO;
using System.Linq;
using GlobalX.Console;
using Xunit;

namespace GlobalX.UnitTests
{
    public class AppTests
    {
        private readonly string _unSortedFileNamePath;
        private readonly string _sortedFileNamePath;

        public AppTests()
        {
            _unSortedFileNamePath = "unsorted-names-list.txt";
            _sortedFileNamePath = "sorted-names-list.txt";
            var fs = File.Create(_unSortedFileNamePath);
            fs.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">This is used just for generating data for testing purposes only</param>
        [Theory]
        [InlineData(
            "Janet Parsons,Vaughn Lewis,Adonis Julius Archer,Shelby Nathan Yoder,Marin Alvarez,London Lindsey,Beau Tristan Bentley,Leo Gardner,Hunter Uriah Mathew Clarke,Mikayla Lopez,Frankie Conner Ritter, ")]
        public void ShouldLoadMapSortAndStoreWhenUnsortedListGiven(string data)
        {
            //Arrange
            var contents = data.Split(',');
            File.WriteAllLines(_unSortedFileNamePath, contents);
            var app = new App(new FileReader(_unSortedFileNamePath), new FileWriter(_sortedFileNamePath), new Sorter());

            //Act
            app.Run(out var sortedList);

            var sortedFileContent = File.ReadAllLines(_sortedFileNamePath);

            //Assert
            Assert.True(File.Exists(_sortedFileNamePath));
            Assert.Equal(contents.Length - 1, sortedFileContent.Length);
            Assert.Equal("Marin Alvarez", sortedFileContent.ToList().First());
            Assert.Equal("Shelby Nathan Yoder", sortedFileContent.ToList().Last());
        }
    }
}
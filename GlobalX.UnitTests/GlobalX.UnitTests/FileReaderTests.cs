using System.IO;
using System.Linq;
using GlobalX.Library;
using Xunit;

namespace GlobalX.UnitTests
{
    public class FileReaderTests
    {
        private readonly string _unSortedFileNamePath;

        public FileReaderTests()
        {
            _unSortedFileNamePath = "filereader.txt";
            var fs = File.Create(_unSortedFileNamePath);
            fs.Close();
        }

        [Fact]
        public void ShouldLoadTheTestFileWithoutAnyErrorWhenExists()
        {
            //Arrange
            var fileReader = new FileReader(_unSortedFileNamePath);

            //Act
            var fileLoaded = fileReader.Load();

            //Assert
            Assert.True(fileLoaded);
        }

        [Fact]
        public void ShouldNotLoadTheTestFileOrAnyErrorWhenFileNotFound()
        {
            //Arrange
            File.Delete(_unSortedFileNamePath);
            var fileReader = new FileReader(_unSortedFileNamePath);

            //Act
            var fileLoaded = fileReader.Load();

            //Assert
            Assert.False(fileLoaded);
        }

        [Fact]
        public void ShouldNotReadFileWhenEmpty()
        {
            //Arrange
            var fileReader = new FileReader(_unSortedFileNamePath);
            fileReader.Load();

            //Act
            var empty = fileReader.IsFileEmpty();

            //Assert
            Assert.True(empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">This is used just for generating data for testing purposes only</param>
        [Theory]
        [InlineData(
            "Janet Parsons,Vaughn Lewis,Adonis Julius Archer,Shelby Nathan Yoder,Marin Alvarez,London Lindsey,Beau Tristan Bentley,Leo Gardner,Hunter Uriah Mathew Clarke,Mikayla Lopez,Frankie Conner Ritter, ")]
        public void ShouldTansformFileContentToList(string data)
        {
            //Arrange
            var contents = data.Split(',');
            File.WriteAllLines(_unSortedFileNamePath, contents);
            var fileReader = new FileReader(_unSortedFileNamePath);
            fileReader.Load();
            fileReader.IsFileEmpty();

            //Act
            var people = fileReader.Map();

            //Assert
            Assert.Equal(contents.Length - 1, people.Count());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">This is used just for generating data for testing purposes only</param>
        [Theory]
        [InlineData("Vaughn, Janet Parsons,Shelby Nathan Yoder,Hunter Uriah Mathew Clarke")]
        public void ShouldMapFirstNameAndLastNameToRespectiveObjects(string data)
        {
            //Arrange
            var contents = data.Split(',');
            File.WriteAllLines(_unSortedFileNamePath, contents);
            var fileReader = new FileReader(_unSortedFileNamePath);
            fileReader.Load();
            fileReader.IsFileEmpty();

            //Act
            var people = fileReader.Map().ToList();

            //Assert
            Assert.Equal(contents.Length, people.Count);
            Assert.Equal("Vaughn", people.ToArray()[0].LastName);
            Assert.Equal("Parsons", people.ToArray()[1].LastName);
            Assert.Equal("Janet", people.ToArray()[1].FirstName);
            Assert.Equal("Yoder", people.ToArray()[2].LastName);
            Assert.Equal("Shelby Nathan", people.ToArray()[2].FirstName);
            Assert.Equal("Clarke", people.ToArray()[3].LastName);
            Assert.Equal("Hunter Uriah Mathew", people.ToArray()[3].FirstName);
        }
    }
}
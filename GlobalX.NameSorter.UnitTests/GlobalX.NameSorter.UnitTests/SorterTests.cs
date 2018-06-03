using System.Collections.Generic;
using System.IO;
using System.Linq;
using GlobalX.Console;
using GlobalX.Library;
using GlobalX.Library.Model;
using Xunit;

namespace GlobalX.UnitTests
{
    public class SorterTests
    {
        [Fact]
        public void ShouldSortBasedOnTheLastNameThenByGivenName()
        {
            //Arrange

            var app = new Sorter();

            //Act

            var unSortedPeople = new List<Person>
            {
                new Person {FirstName = "Janet", LastName = "Parsons"},
                new Person {FirstName = "Adonis Julius", LastName = "Archer"},
                new Person {FirstName = "Hunter Uriah Mathew", LastName = "Clarke"}
            };
            var sortedPeople = app.Sort(unSortedPeople).ToList();

            //Assert
           
            Assert.Equal(unSortedPeople.Count, sortedPeople.Count());
            Assert.Equal("Adonis Julius Archer", sortedPeople.First().FullName);
            Assert.Equal("Janet Parsons", sortedPeople.Last().FullName);
        }
    }
}
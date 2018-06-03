using System.Collections.Generic;
using System.Linq;
using GlobalX.Library.Interfaces;
using GlobalX.Library.Model;

namespace GlobalX.Library
{
    public class Sorter: ISorter<IEnumerable<Person>, IOrderedEnumerable<Person>>
    {
        public IOrderedEnumerable<Person> Sort(IEnumerable<Person> unSortedPeople)
        {
            return unSortedPeople.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
        }

    }
}


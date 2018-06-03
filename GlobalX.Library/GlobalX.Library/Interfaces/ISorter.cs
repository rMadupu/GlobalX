using System.Collections.Generic;
using GlobalX.Library.Model;

namespace GlobalX.Library.Interfaces
{
    public interface ISorter<in T, out T1> where T : IEnumerable<Person>
    {
        T1 Sort(T unSortedList);
    }
}
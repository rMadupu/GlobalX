using System.Linq;

namespace GlobalX.Library.Interfaces
{
    public interface IWriter<in T>
    {
        void Store(IOrderedEnumerable<T> sortedList);
    }
}
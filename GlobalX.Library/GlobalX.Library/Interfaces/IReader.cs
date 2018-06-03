using System.Collections.Generic;

namespace GlobalX.Library.Interfaces
{
    public interface IReader<out T>
    {
        bool Load();
        IEnumerable<T> Map();
        bool IsFileEmpty();
    }
}
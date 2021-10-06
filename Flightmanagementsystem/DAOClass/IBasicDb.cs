using System.Collections.Generic;

namespace Flightmanagementsystem
{
    public interface IBasicDb<T>
    {
        public void Add(T t);
        public T Get(int id);
        public IList<T> GetAll();
        public void Remove(T t);
        public void Update(T t);

    }
}

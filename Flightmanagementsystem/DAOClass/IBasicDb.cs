using System.Collections.Generic;

namespace Flightmanagementsystem.DAOClass
{
    public interface IBasicDb<T>
    {
        public void Add(T t);
        public T Get(long id);
        public IList<T> GetAll();
        public void Remove(T t);
        public void Update(T t);

    }

}

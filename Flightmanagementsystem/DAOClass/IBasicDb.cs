using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Npgsql;

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

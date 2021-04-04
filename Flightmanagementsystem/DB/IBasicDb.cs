using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Npgsql;

namespace Flightmanagementsystem
{
    interface IBasicDb<T>
    {
        public void Add();

        public void Get();
        public void GetAll();
        public void Remove();
        public void Update();

    }
}

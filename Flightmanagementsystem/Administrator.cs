using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    class Administrator : IPoco , IUser
    {
        public Int64 Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Level { get; set; }
        public Int64 User_Id { get; set; }

        public Administrator()
        {
        }

        public Administrator(long id, string first_Name, string last_Name, int level, long user_Id)
        {
            Id = id;
            First_Name = first_Name;
            Last_Name = last_Name;
            Level = level;
            User_Id = user_Id;
        }
    }


}

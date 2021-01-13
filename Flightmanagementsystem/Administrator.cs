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


    }


}

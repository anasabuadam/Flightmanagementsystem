using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    class Administrator : IPoco , IUser
    {
        User User = new User();
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

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
        public static bool operator !=(Administrator administrator, Administrator administrator1)
        {
            return !(administrator == administrator1);
        }
        public static bool operator ==(Administrator administrator, Administrator administrator1)
        {
            return administrator == administrator1;
        }
        public override bool Equals(object obj) => obj is Administrator administrator &&
                   Id == administrator.Id;
    }


}

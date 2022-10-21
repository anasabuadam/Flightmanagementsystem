﻿using Flightmanagementsystem.DAOClass;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flightmanagementsystem.BasicFolderClass
{
    public class Administrator : IAdminDAO,IUser
    {
        User User = new User();
        [Required]
        public long Id { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public long User_Id { get; set; }
    

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
        public override bool Equals(object obj)
        {
            return obj is Administrator company &&
                   Id == company.Id;
        }

        public override int GetHashCode()
        {
            return +Id.GetHashCode();
        }
        public static bool operator ==(Administrator administrator, Administrator administrator1)
        {
            return administrator.Id == administrator1.Id;
        }
        public static bool operator !=(Administrator administrator, Administrator administrator1)
        {
            return !(administrator == administrator1);
        }








    }
}

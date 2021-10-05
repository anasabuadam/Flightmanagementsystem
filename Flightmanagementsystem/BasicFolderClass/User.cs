using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
   public  class User : IPoco
    {
        public Int64 Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Int32 User_Role { get; set; }

        public User()
        {
            
        }

        public User(long id, string username, string password, string email, int user_Role)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            User_Role = user_Role;
        }
        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id == user.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Username, Password, Email, User_Role);
        }

        public static bool operator !=(User user, User user1)
        {
            return !(user == user1);
        }
        public static bool operator ==(User user, User user1)
        {
            return user == user1;
        }

        
    }
}

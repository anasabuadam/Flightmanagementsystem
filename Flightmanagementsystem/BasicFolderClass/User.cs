using System;

namespace Flightmanagementsystem.BasicFolderClass
{
    public class User : IPoco, IUser
    {
        public long _Id { get; set; }
        public string _Username { get; set; }
        public string _Password { get; set; }
        public string _Email { get; set; }
        public int _User_Role { get; set; }

        public User()
        {

        }

        public User(long id, string username, string password, string email, int user_Role)
        {
            _Id = id;
            _Username = username;
            _Password = password;
            _Email = email;
            _User_Role = user_Role;
        }

        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   _Id == user._Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_Id, _Username, _Password, _Email, _User_Role);
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

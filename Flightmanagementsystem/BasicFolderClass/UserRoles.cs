using System;

namespace Flightmanagementsystem
{
    public class UserRoles : IUser
    {
        public Int32 Id { get; set; }
        public string Role_Name { get; set; }

        public UserRoles()
        {
        }

        public UserRoles(int id, string role_Name)
        {
            Id = id;
            Role_Name = role_Name;
        }
        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
            return obj is UserRoles roles &&
                   Id == roles.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
        public static bool operator !=(UserRoles userRoles, UserRoles userRoles1)
        {
            return !(userRoles == userRoles1);
        }
        public static bool operator ==(UserRoles userRoles, UserRoles userRoles1)
        {
            return userRoles == userRoles1;
        }
    }
}

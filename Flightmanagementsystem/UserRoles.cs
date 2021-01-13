using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    class UserRoles
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
    }
}

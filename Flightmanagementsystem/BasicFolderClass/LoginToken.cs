using System;

namespace Flightmanagementsystem.BasicFolderClass
{
    public class LoginToken<T> : ILoginToken where T : IUser
    {
       
    
        public T _user { get; set; }


    }
}



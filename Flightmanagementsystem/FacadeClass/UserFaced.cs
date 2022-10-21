using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.DAOClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem.FacadeClass
{
    public class UserFaced : FacadeBase , IUserFaced
    {
        public IList<User> GetAllUser()
        {
            UserDAOPGSQL dAOPGSQL = (UserDAOPGSQL)_userDAO;
            return dAOPGSQL.GetAllUsers();
        }

        //IList<Flight> IAnonymousUserFacade.GetAllFlights()
        public User Get(long id)
        {

            UserDAOPGSQL user = (UserDAOPGSQL)_userDAO;
            return (User)user.Get(id);
        }

        public User Add(User user)
        {
            UserDAOPGSQL dAOPGSQL = (UserDAOPGSQL)_userDAO;
           return dAOPGSQL.Add(user);
        }
        public User Update(User user)
        {
            UserDAOPGSQL dAOPGSQL = (UserDAOPGSQL)_userDAO;
            return (User)dAOPGSQL.Update(user);
        }
        public User Remove(User user)
        {
            UserDAOPGSQL dAOPGSQL = (UserDAOPGSQL)_userDAO;
            return dAOPGSQL.Remove(user);
        }


    }
}

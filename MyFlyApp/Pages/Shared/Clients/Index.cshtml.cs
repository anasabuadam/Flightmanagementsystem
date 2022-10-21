using Flightmanagementsystem.BasicFolderClass;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Flightmanagementsystem.DAOClass;
using System.Data.SqlClient;



namespace MyFlyApp.Pages.Shared.Clients
{
    public class IndexModel : PageModel
    {

        public  IList<User> users = new List<User>();
        public UserDAOPGSQL UserDAOPGSQL = new UserDAOPGSQL();
        public void OnGet()
        {
            users = UserDAOPGSQL.GetAllUsers().ToList();
        }



    }
    
}    

 
   


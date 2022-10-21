using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.DAOClass;
using Flightmanagementsystem.FacadeClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MyFlyApp.Pages.Shared.Clients
{
    public class CreateUserModel : PageModel
    {



        public User user = new User();
   
        public UserDAOPGSQL UserDAOPGSQL = new UserDAOPGSQL();

        public  ActionResult OnPost(User user)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

             UserDAOPGSQL.Add(user);
            return RedirectToPage("./Index");
        }
        
    }  
}


using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.DAOClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.PortableExecutable;

namespace MyFlyApp.Pages.Shared.Clients
{
    public class EditUserModel : PageModel
    {
        public readonly  User user1 = new User();
        public readonly UserDAOPGSQL UserDAOPGSQL = new UserDAOPGSQL();
       
        public ActionResult OnGet(long id)
        {
          User  user = UserDAOPGSQL.Get(id);
            if(id > 0)
            {
                return Page();
               
            }
            else

                return RedirectToPage("./Index");
           
        }
 
        public ActionResult Update(User user)
        {

            if (!ModelState.IsValid)
            {
                return Page();
              
            }
            user = UserDAOPGSQL.Update(user1);
            return RedirectToPage("./Index");

        }

        

    }
}

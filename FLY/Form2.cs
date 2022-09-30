using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flightmanagementsystem;
using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.DAOClass;
using Flightmanagementsystem.FacadeClass;

namespace FLY
{
    
    public partial class Form2 : Form
    {
        Administrator Administrator = new Administrator();
        User User = new User();
        AirlineCompany AirlineCompany = new AirlineCompany();
        Customer Customer = new Customer();


        public Form2()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginService loginService = new LoginService();
           loginService.TryAdminLogin(textBox1.Text , textBox2.Text , out LoginToken<Administrator> login);
            if (login._user.First_Name == null)
            {
                MessageBox.Show(Text = "Erorr");
            }
            else
            {
                Form1 form1 = new Form1();
                form1.ShowDialog(this);
                form1.Owner = this;
                form1.Activate();
     
            }
               
            
            


           
           


        }
    }
}

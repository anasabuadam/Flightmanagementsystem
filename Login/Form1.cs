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
using Flightmanagementsystem.FacadeClass;
using System;

namespace Login
{
    public partial class Form1 : Form
    {
        FormAdmin FormAdmin = new FormAdmin();
        Customer customer = new Customer();
        UserForm userForm = new UserForm();
        Administrator administrator1 = new Administrator();        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }



        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            textBox1.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;

            textBox2.BackColor = Color.White;
            panel5.BackColor = Color.White;
            textBox2.BackColor = SystemColors.Control;
            panel5.BackColor = SystemColors.Control;


            
        }



        private void button2_Click(object sender, EventArgs e)
        {

            LoginService login = new LoginService();
            LoginToken<Administrator> loginToken = new LoginToken<Administrator>();
            _ = login.TryAdminLogin(textBox1.Text, textBox2.Text,out loginToken);
            if(true)
            {
                userForm.Show();
                this.Hide();
            }
            else
            {
                throw new AccessViolationException("fild login");
            }
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

  
    }
}


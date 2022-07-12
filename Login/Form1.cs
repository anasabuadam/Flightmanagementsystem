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

namespace Login
{
    public partial class Form1 : Form
    {
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = PasswordPropertyTextAttribute.Yes.Password.ToString();
        }

        private void button2_Click(object sender, EventArgs e )
        {
            LoginService loginService = new LoginService();
            
            if( _ = loginService.TryAdminLogin(textBox1.Text, textBox2.Text, out LoginToken<Administrator> token))
            {
                MessageBox.Show("Login Successful");
               
            }
            MessageBox.Show("Login Failed");
            
           






        }
    }
}

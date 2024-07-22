using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _43230350_MogotlaneNick_Exam
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 UserAccount = new Form1();
            this.Hide();   //Hiding the Login Form 
            UserAccount.ShowDialog();   //Redirecting the user to the User Account form
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Checking if email and password are entered before login
            if(txtEmail.Text == "")
            {
                errorProviderEmail.SetError(txtEmail, "Enter the email.");
                txtEmail.Focus();
            }
            if(txtPassword.Text == "")
            {
                errorProviderPassword.SetError(txtPassword, "Enter your password");
                txtPassword.Focus();
            }
            //this.Close();
            this.Hide();    //Hiding the login form
            
        }
    }
}

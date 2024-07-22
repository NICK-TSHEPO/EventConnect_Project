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
    public partial class Form5 : Form
    {
        public int id { get; set; }
        public Form5()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
            
            if(txtEventID.Text == "")
            {
                //Giving the User error message if the user didn't enter anything
                MessageBox.Show("Enter Event ID to cancel the event.");
            }
            
            id = Convert.ToInt32(txtEventID.Text);  //Converting the users enter text into Integer
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //Hiding the instruction label on how to delete in the form load to reveal it if the user click the linkLabel on how to delete
            lblInstruction.Hide();
        }

        private void linkLabelInstruction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Revealing the instruction of how to cancel event if the user click linkLabel of How to delete the event
            lblInstruction.Visible = true;

        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 User_Hosts = new Form4();
            this.Hide();   //Hiding the Form of cancelling the event
            User_Hosts.ShowDialog();   //Redirecting the user to the Hosts dashboard 
        }

        private void txtEventID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

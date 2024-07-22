using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace _43230350_MogotlaneNick_Exam
{
    public partial class Form2 : Form
    {
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter dataAdapter;
        SqlDataReader dataReader;
        Form1 UserAccount = new Form1();
      
        public Form2()
        {
            InitializeComponent();
        }

        private void linkLabel_LogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 UserAccount = new Form1();
            this.Hide();   //Hiding the Normal User dashboard  
            UserAccount.ShowDialog();   //Redirecting the user to the User Account form
        }

        private void btnUserAccount_Click(object sender, EventArgs e)
        {

            Form1 UserAccount = new Form1();
            UserAccount.lblOperation.Text = "UPDATE";   //Changing the lblOperation displaying User Account to UPDATE 
            UserAccount.btnSignUp.Text = "DONE";    //button SignUp to DONE
            UserAccount.linkLabelSignIn.Text = "Cancel"; //and changing the linkLabel Sign to cancel 
            this.Hide();   // Hiding the Normal User dashboard
            UserAccount.ShowDialog();   //Redirecting the user to the User Account form to update
        }

        public void displayEvents(String sqlStatement)  //Creating the method for displaying data
        {
            conn = new SqlConnection(UserAccount.conString);    //Establishing the connection

            conn.Open();    //Opening the connection

            try
            {

                String sql_display = sqlStatement;
                comm = new SqlCommand(sql_display, conn);

                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = comm;
              
                //Populating the Events in the dataGridView named ggvEvents 
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "EVENTS");
                dgvEvents.DataSource = ds;
                dgvEvents.DataMember = "EVENTS";
            }
            catch(SqlException exe)
            {
                MessageBox.Show(exe.Message);
            }      

            conn.Close();   //Closing the connection in the database

        }
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            Form4 HostForm = new Form4();
            const decimal VAT = 0.15M;  
            decimal Incl_Vat = decimal.Parse(HostForm.txtFee.Text);
            decimal Charged_Vat = VAT * Incl_Vat;   //Calculating the charged vat 

            //Printing the invoice when the user press Request Invoice button
            lstInvoice.Items.Add("-----------------------------------------------------------------");
            lstInvoice.Items.Add("Description" + "\t" + "Tax" + "\t\t" + "Total Amount due(including Tax)" + "\t" + "Date of Issue");
            lstInvoice.Items.Add(HostForm.txtCustomerName.Text + "\t" + "R " + Charged_Vat + "\t\t" + "R " + Incl_Vat + "\t\t\t" + HostForm.dateTimePicker.Text);
            lstInvoice.Items.Add("-------------------------------END-------------------------------");
        }

        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Filtering the Events in the dataGridView according to the phrase the user entered
            displayEvents($"SELECT * FROM EVENTS WHERE Event_Name LIKE '%{txtSearch.Text}%'");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //Displaying all the events in the dataGridView when the user click Refresh button
            displayEvents("SELECT * FROM EVENTS");
            lstInvoice.Items.Clear();   //Clearing the invoice displayed in the listBox
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            displayEvents("SELECT * FROM EVENTS");  //Populating all the events in the dataGridView during the form load
        }
    }
}

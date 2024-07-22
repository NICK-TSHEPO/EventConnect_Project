using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _43230350_MogotlaneNick_Exam
{

    public partial class Form4 : Form
    {
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter dataAdapter;
        SqlDataReader dataReader;
        Form1 UserAccount = new Form1();   
        
        public Form4()
        {
            InitializeComponent();
        }

        public void display(String sqlStatement)    //Creating the method for filtering events in the dataGridView
        {
            conn = new SqlConnection(UserAccount.conString);    //Establishing the connection string

            conn.Open();    //Opening the connection in the database

            String sql_display = sqlStatement;
            comm = new SqlCommand(sql_display, conn);

            dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = comm;
            //dataAdapter.SelectCommand.ExecuteNonQuery();

            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "EVENTS");
            dataGridView.DataSource = ds;
            dataGridView.DataMember = "EVENTS";

            conn.Close();   //Closing the connection in the database

        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(UserAccount.conString);    //Establishing the connection
   
            conn.Open();    //Opening the connection in the database

            try
            {
                //SQL Statement for displaying All the registered Users
                string sql_display = "SELECT * FROM USERS";
                comm = new SqlCommand(sql_display, conn);

                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = comm;

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "USERS");
                dataGridView.DataSource = ds;
                dataGridView.DataMember = "USERS";
            }
            catch(SqlException exe)
            {
                MessageBox.Show(exe.Message);
            }
            
            conn.Close();   //Closing the connection in the database
           
        }

        private void btnUserAccount_Click(object sender, EventArgs e)
        {
            Form1 UserAccount = new Form1();
            UserAccount.lblOperation.Text = "UPDATE";   //Changing the lblOperation displaying User Account to UPDATE 
            UserAccount.btnSignUp.Text = "DONE";    //button SignUp to DONE
            UserAccount.linkLabelSignIn.Text = "Cancel"; //and changing the linkLabel Sign to cancel 
            this.Hide();   // Hiding the Hosts User dashboard
            UserAccount.ShowDialog();   //Redirecting the user to the User Account form to update

       
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Form5 CancelEvent = new Form5();
            CancelEvent.ShowDialog();   //Redirecting the User to the CancelEvent Form to get the ID for deleting

            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();    //Opening the connection in the database if is closed
            }

            try
            {
                //SQL Statement for deleting event using event ID
                string sql_delete = "DELETE FROM EVENTS WHERE ID = @id";
                comm = new SqlCommand(sql_delete, conn);
                comm.Parameters.AddWithValue("@id", CancelEvent.id);
                comm.ExecuteNonQuery();
                
                //Giving the user message that event was successfully deleted
                MessageBox.Show("Event was successfully cancelled.");
                display("SELECT * FROM EVENTS");    //Refreshing the dataGridView to show that the deleted event is deleted.
            }
            catch(SqlException exe)
            {
                MessageBox.Show(exe.Message);
            }
            conn.Close();   //Closing the connection in the database
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Filtering the dataGridView for searching events according to phrase that is in event location or event name  
            display($"SELECT * FROM EVENTS WHERE Event_Name LIKE '%{txtSearch.Text}%' OR Event_Location = '%{txtEventLocation.Text}%'"); 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(UserAccount.conString);   //Establishing the connection string 
            conn.Open();    //Opening the connection in the database
            try
            {
                //Receiving and storing all the details required to host event
                string customerName = txtCustomerName.Text;
                string customerEmail = txtCustomerEmail.Text;
                string eventName = txtEventName.Text;
                string eventLocation = txtEventLocation.Text;
                string eventVenueCapacity = txtVenue_Capacity.Text;
                string categorty = txtCategory.Text;
                decimal price_paid;              
                string eventDate = txtEventDate.Text;
                string eventTime = txtTime.Text;            

                if (!decimal.TryParse(txtFee.Text, out price_paid)) 
                {
                    price_paid = 0M;    //Initializing the Price Paid for the event to zero if Invalid Fee was entered
                }
                
                //SQL Statement for Inserting the event(s) in the EVENTS Table
                string sql_add = $"INSERT INTO EVENTS(Customer_Name, Customer_Email, Event_Name, Event_Location, Event_Venue_Capacity, Event_Category, Fee_Paid, Event_Date, Event_Time) VALUES('{customerName}', '{customerEmail}', '{eventName}', '{eventLocation}', '{eventVenueCapacity}', '{categorty}', '{price_paid}', '{eventDate}', '{eventTime}')";
                comm = new SqlCommand(sql_add, conn);

                dataAdapter = new SqlDataAdapter();
                dataAdapter.InsertCommand = comm;
                dataAdapter.InsertCommand.ExecuteNonQuery();

                //Giving the user the message that events was added successfully
                MessageBox.Show("Event was added successfully.");
                

                const decimal VAT = 0.15M;  
                decimal Charged_Vat = VAT * price_paid; //Calculating charged tax

                //Displaying the Customer invoice after booking event
                lstInvoice.Items.Add("-----------------------------------------------------------------");
                lstInvoice.Items.Add("Description" + "\t" + "Tax" + "\t\t" + "Total Amount due(including Tax)" + "\t" + "Date of Issue");
                lstInvoice.Items.Add(customerName + "\t\t" + "R " + Charged_Vat + "\t\t\t\t" + "R " + price_paid + "\t\t\t" + dateTimePicker.Text);
                lstInvoice.Items.Add("***************************END***************************");

                //Clearing and deselecting everything to allow new booking to be made
                txtCustomerName.Text = "";
                txtCustomerEmail.Text = "";
                txtEventName.Text = "";
                txtEventLocation.Text = "";
                txtVenue_Capacity.Text = "";
                txtCategory.Text = "";
                txtFee.Text = "";
                txtEventDate.Text = "";
                txtTime.Text = "";

                //Refreshing datagridView to show all the events including events created 
                display("SELECT * FROM EVENTS");
            }
            catch(SqlException exe)
            {
                MessageBox.Show(exe.Message);
            }

            conn.Close();   //Closing the connection in the database
        }

        private void Form4_Load(object sender, EventArgs e)
        {
          
            lstInvoice.Items.Clear();   //Clearing the listBox for showing the invoice in form load
            display("SELECT * FROM EVENTS");    //Populating the dataGridView with all the events in the form load
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            display("SELECT * FROM EVENTS");   //Displaying all the events after searching when the user click button Refresh

            //Clearing all and deselecting everything when the user click button Refresh
            txtCustomerName.Text = "";
            txtCustomerEmail.Text = "";
            txtEventName.Text = "";
            txtEventLocation.Text = "";
            txtVenue_Capacity.Text = "";
            txtCategory.Text = "";
            txtFee.Text = "";
            txtEventDate.Text = "";
            txtTime.Text = "";

            
            lstInvoice.Items.Clear();   //Clearing the listBox 
        }

        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            //Receiving and storing all the details required to host event
            string customerName = txtCustomerName.Text;
            string customerEmail = txtCustomerEmail.Text;
            string eventName = txtEventName.Text;
            string eventLocation = txtEventLocation.Text;
            string eventVenueCapacity = txtVenue_Capacity.Text;
            string categorty = txtCategory.Text;
            decimal price_paid;
            string eventDate = txtEventDate.Text;
            string eventTime = txtTime.Text;

            if (!decimal.TryParse(txtFee.Text, out price_paid))
            {
                price_paid = 0M;    //Initializing the Price Paid for the event to zero if Invalid Fee was entered
            }



            conn = new SqlConnection(UserAccount.conString);
            conn.Open();    //Opening the connection in the database
            try
            {
                //SQL Statement for Updating the Event time, date using customer name
                string update_sql = "UPDATE EVENTS SET EventTime = @event_time, Event_Date = @event_date  WHERE CustomerName = @customer_name";
                comm = new SqlCommand(update_sql, conn);
                dataAdapter = new SqlDataAdapter();


                comm.Parameters.AddWithValue("@event_time", txtTime.Text);
                comm.Parameters.AddWithValue("@event_date", txtEventDate);
                comm.Parameters.AddWithValue("@customer_name", txtCustomerName.Text);

                comm.ExecuteNonQuery();
                           
                MessageBox.Show("Event was updated successfully."); //Showing the user that the event was successfully updated
                display("SELECT * FROM EVENTS");    //Refreshing the dataGridView to show the user that the event was updated

                //Clearing and deselecting the everything to allow new event to be updated or added
                txtCustomerName.Text = "";
                txtCustomerEmail.Text = "";
                txtEventName.Text = "";
                txtEventLocation.Text = "";
                txtVenue_Capacity.Text = "";
                txtCategory.Text = "";
                txtFee.Text = "";
                txtEventDate.Text = "";
                txtTime.Text = "";
            }
            catch(SqlException exe)
            {
                MessageBox.Show(exe.Message);
            }

             conn.Close();  //Closing the connection in the database
         }

         private void btnLogOut_Click(object sender, EventArgs e)
         {
             Form1 UserAccount = new Form1();
             this.Hide();   //Hiding the Login Form
             UserAccount.ShowDialog();   //Redirecting the user to the Hosts dashboard 
         }

         private void btnInvoice_Click(object sender, EventArgs e)
         {
            
         }

        private void gbOperations_Enter(object sender, EventArgs e)
        {

        }
    }
}

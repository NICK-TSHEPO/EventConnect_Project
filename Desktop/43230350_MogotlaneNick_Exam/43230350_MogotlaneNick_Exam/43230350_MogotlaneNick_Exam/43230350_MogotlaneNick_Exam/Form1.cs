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
    public partial class Form1 : Form
    {
        //Declaring variables
        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter dataAdapter;
        SqlDataReader dataReader;
        //Declaring connection string globally
        public string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\43230350\source\repos\43230350_MogotlaneNick_Exam\43230350_MogotlaneNick_Exam\EventConnectDB.mdf;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabelExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Terminating the program
            Application.Exit();
        }

        private void linkLabelSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            Form3 Login = new Form3();          
            this.Hide();   //Hiding the User Account Form
            Login.ShowDialog();   //Redirecting the user to the Login form

            conn = new SqlConnection(conString);
            conn.Open();    //Opening the connection

            try
            {
                string sql_select = "SELECT * FROM USERS";
                comm = new SqlCommand(sql_select, conn);

                dataReader = comm.ExecuteReader();

                //Using connect@gmail.com as email and connect as password to login for hosts
                if (Login.txtEmail.Text == "connect@gmail.com" && Login.txtPassword.Text == "connect")
                {
                    Form4 User_Hosts = new Form4();
                    this.Hide();   //Hiding the Login Form
                    User_Hosts.ShowDialog();   //Redirecting the user to the Hosts dashboard 
                }
                else
                {
                    while (dataReader.Read())   //Reading data that is in USERS Table
                    {
                        //Checking if email and pasword entered are found in the row(s) of the USERS Table
                        if (dataReader.GetValue(2).ToString() == Login.txtEmail.Text && dataReader.GetValue(6).ToString() == Login.txtPassword.Text)
                        {
                            //If the Membership Type is:
                            if (dataReader.GetValue(4).ToString() == "Basic") //Basic
                            {
                                Form2 NormalUser = new Form2();
                                this.Hide();   //Hiding the Login Form
                                NormalUser.ShowDialog();   //Redirecting the user to the Normal User dashboard form
                            }
                            if (dataReader.GetValue(4).ToString() == "Premium") //Premium
                            {
                                Form4 User_Hosts = new Form4();
                                this.Hide();   //Hiding the Login Form
                                User_Hosts.ShowDialog();   //Redirecting the user to the Hosts dashboard 
                            }
                            else
                            {
                                //Give the user error message that email or password is incorrect and clearing all the textBoxes in Login Form
                                MessageBox.Show("Invalid password or email.");
                                Login.txtEmail.Clear();
                                Login.txtPassword.Clear();
                                Login.txtEmail.Focus(); //Changing focus to the email textBox
                            }
                        }

                        //Give the user error message that email or password is incorrect and clearing all the textBoxes in Login Form MessageBox.Show("You entered invalid email or password!");
                        Form3 login = new Form3();
                        //this.Hide();   //Hiding the Login Form
                        login.ShowDialog();   //Redirecting the user to the login form 

                        if(linkLabelSignIn.Text == "Cancel") 
                        {
                            //linkLabelSignIn.Visible = true;
                            linkLabelSignIn.Text = "Sign In";   //Change labelLink text to Sign in
                            btnSignUp.Text = "Sign Up"; //button sign up text to SignUp
                        }
                    }
                }
            }
            catch(SqlException exe)
            {
                MessageBox.Show(exe.Message);
            }
            
            conn.Close();   //Closing the connection in the database
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(conString);    //Establishing the connection
                conn.Open();    //Opening the connection in the database

                //Receiving and storing the data in the following variable for the customer
                string name = txtName.Text; //name and surname
                string email = txtEmail.Text;   //email 
                string address = txtAddress.Text;   //and the address

                decimal price_paid; //membership price
                string password = txtPassword.Text; //created password
              
                string membership;  //membership type
                //if the radion button:
                if (rdoBasic.Checked)   //rdoBasic is  checked
                {
                    membership = "Basic";   //initialize membership type to basic
                    price_paid = 1500M; //and the membership price to R1500
                }
                else if (rdoPremium.Checked)    //rdoPremium is  checked
                {
                    membership = "Premium"; //initialize membership type to Premium
                    price_paid = 2500M; //and the membership price to R2500
                }
                else
                {
                        
                    membership = "Basic";   //if not checked make membership type Basic 
                    price_paid = 0M;    //and the membership price paid R0
                }


                if (lblOperation.Text == "UPDATE")  
                {
                    linkLabelSignIn.Text = "Cancel";


                    //SQL Statement for allowing Normal User to update the Email, Membership type, and the Password Using the Name and Surname
                    //string sql_update = $"UPDATE USERS SET Email = '{email}', Membership = '{membership}', Password ='{password}' WHERE Name LIKE '{name}'";
                    string sql_update = $"UPDATE USERS SET Email = @email, Membership = @membership, Password = @password WHERE Name = @name";
                    comm = new SqlCommand(sql_update, conn);
                    dataAdapter = new SqlDataAdapter();

                    comm.Parameters.AddWithValue("@email", txtEmail.Text);
                    comm.Parameters.AddWithValue("@membership", membership);
                    comm.Parameters.AddWithValue("@password", txtPassword.Text);
                    comm.Parameters.AddWithValue("@name", txtName.Text);
                    comm.ExecuteNonQuery();
                 
                    MessageBox.Show("Profile was updated successfully.");   //Giving the user message that the profile was successfully updated

                    //Clearing and deselecting everything after updating profile to allow another profile to be updated
                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtAddress.Text = "";
                    rdoBasic.Checked = false;
                    rdoPremium.Checked = false;
                    txtPassword.Text = "";

                }
                else
                {
                    
                   //Checking if the textBoxes are not empty before registering the user if so give the user the error message(s) 
                    if (txtName.Text == "")
                    {
                        errorProviderName.SetError(txtName, "Enter name and surname.");
                        txtName.Focus();
                    }
                    else if (txtEmail.Text == "")
                    {
                        errorProviderEmail.SetError(txtEmail, "Enter email.");
                        txtEmail.Focus();
                    }
                    else if (txtPassword.Text == "")
                    {
                        errorProviderPassword.SetError(txtPassword, "Please create a password.");
                        txtPassword.Focus();
                    }
                    else
                    {
                        //SQL Statement for Inserting data entered for registration in the USERS Table
                        string sql_add = $"INSERT INTO USERS(Name, Email, Address, Membership, Price_Paid, Password) VALUES('{name}', '{email}', '{address}', '{membership}', '{price_paid}', '{password}')";
                        comm = new SqlCommand(sql_add, conn);

                        dataAdapter = new SqlDataAdapter();
                        dataAdapter.InsertCommand = comm;
                        dataAdapter.InsertCommand.ExecuteNonQuery();

                        //Giving the user message that registration was completed successfully 
                        MessageBox.Show("Registration was completed successfully.");

                        //Clearing and deselecting everything to allow new registration to be made
                        txtName.Text = "";
                        txtEmail.Text = "";
                        txtAddress.Text = "";
                        rdoBasic.Checked = false;
                        rdoPremium.Checked = false;
                        txtPassword.Text = "";
                    }
                    
                    
                }
                conn.Close();   //Closing the connection in the database

            }
            catch(SqlException exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(conString);    //Establishing the connection the load Form
            conn.Open();   //Opening the connection in the database
            conn.Close();   //Closing the connection in the database
        }
    }
}

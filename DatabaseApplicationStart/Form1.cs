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
using System.Configuration;

namespace DatabaseApplicationStart
{
    public partial class Form1 : Form
    {

        public static int id;
        public static string firstName;
        public static string lastName;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getUserData();
        }

        public void getUserData()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["root"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand();

            command.Connection = connection;

            command.CommandText = "select * from Users";

            connection.Open();

            SqlDataReader datareader = command.ExecuteReader();

            while (datareader.Read())
            {

                id = (int)datareader[0];

                firstName = (String)datareader["FirstName"];

                
                lastName = (String)datareader["LastName"];

                this.lblInfo.Text += id + "\n";
                this.lblInfo.Text += firstName + "\n";
                this.lblInfo.Text += lastName + "\n";

            }
            datareader.Close();
            connection.Close();
        
        }
    }
}

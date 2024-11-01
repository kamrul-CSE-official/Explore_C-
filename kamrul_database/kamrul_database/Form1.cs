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

namespace kamrul_database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. Address of SQL server and database
            string connectionString = "Data Source=kamrul;Initial Catalog=normalUsers;Integrated Security=True";

            //2. Establish connections
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                //3. Open Connection
                con.Open();

                //4. Prepare query
                string FastName = tbFastName.Text;
                string LastName = tbLastname.Text;
                string Email = tbEmail.Text;
                string Gender = cbGender.SelectedItem?.ToString();  // Ensure this is not null
                string Query = $"INSERT INTO tbl_user (FastName, LastName, Email, Gender) VALUES (@FastName, @LastName, @Email, @Gender);";

                //5. Execute query with parameters to prevent SQL injection
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@FastName", FastName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Gender", Gender);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Data has been saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                //6. Close connection
                con.Close();
            }

        }

       
        

      
    }
}

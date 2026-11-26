using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using LendingSystem.Data;
namespace LendingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                using(SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    lblStatus.Text = "Connected Successfully";
                    lblStatus.ForeColor = Color.Green;
                }
            }
            catch(Exception ex)
            {
                lblStatus.Text = "Connection Failed!";
                lblStatus.ForeColor = Color.Red;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCountCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Customers";
                    using(SqlCommand command =
                        new SqlCommand(query, connection))
                    {
                        int total = Convert.ToInt32(
                            command.ExecuteScalar());

                        MessageBox.Show("Total Customers: " + total);
                    }
                }
            }
            catch (Exception ex)
            {
              
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using LendingSystem.Data;
using LendingSystem.Interfaces;
using LendingSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        private void btnLoadCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                ICustomerRepository repository = new CustomerRepository();

                var customers = repository.GetAll();

                MessageBox.Show(
                    $"Successfully retrieved {customers.Count} customer(s)."
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error retrieving customers: " + ex.Message
                );
            }
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ICustomerRepository repository = new CustomerRepository();
                var customers = repository.GetAll();

                if(customers.Count == 0)
                {
                    MessageBox.Show("No customer found");
                    return;
                }
                int customerId = customers[0].CustomerId;
                var customer = repository.GetById(customerId);
                
                if(repository != null)
                {
                    MessageBox.Show(
                        $"Customer Found!\n" +
                        $"ID: {customer.CustomerId}\n" +
                        $"Name: {customer.Fullname}\n" +
                        $"Address: {customer.Address}"
                        );
                }
                else
                {
                    MessageBox.Show("Customer not found");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ICustomerRepository repository = new CustomerRepository();

                Customer customer = new Customer
                {
                    Fullname = "Maria Santos",
                    Address = "Davao de Oro",
                    ContactNumber = "09123456789",
                    EmploymentStatus = "Employed",
                    IsActive = true
                };

                repository.Add(customer);

                MessageBox.Show(
                    $"Customer successfully added!\nCustomer ID: {customer.CustomerId}"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message);
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ICustomerRepository repository = new CustomerRepository();

                var customers = repository.GetAll();

                if (customers.Count == 0)
                {
                    MessageBox.Show("No customers found.");
                    return;
                }

                Customer customer = customers[customers.Count - 1];

                customer.Fullname = "Maria Santos Updated";
                customer.Address = "Tagum City, Davao del Norte";
                customer.ContactNumber = "09987654321";
                customer.EmploymentStatus = "Self-Employed";

                repository.Update(customer);

                MessageBox.Show("Customer successfully updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message);
            }
        }

        private void btnDeactivateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                ICustomerRepository repository = new CustomerRepository();

                var customers = repository.GetAll();

                if (customers.Count == 0)
                {
                    MessageBox.Show("No customers found.");
                    return;
                }

                Customer customer = customers[customers.Count - 1];

                repository.Deactivate(customer.CustomerId);

                MessageBox.Show(
                    $"Customer {customer.Fullname} has been deactivated."
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

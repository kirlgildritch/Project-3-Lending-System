using LendingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LendingSystem.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LendingSystem.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
             
            string query = @"
                SELECT
                    CustomerId, 
                    Fullname, 
                    Address, 
                    ContactNumber,
                    EmploymentStatus,
                    IsActive,
                    CreatedAt
                FROM Customers";

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                                Fullname = reader.GetString(reader.GetOrdinal("Fullname")),
                                Address = reader.GetString(reader.GetOrdinal("Address")),
                                ContactNumber = reader.GetString(reader.GetOrdinal("ContactNumber")),

                                EmploymentStatus = reader.IsDBNull(reader.GetOrdinal("EmploymentStatus"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("EmploymentStatus")),

                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }
            return customers;
        }
        public Customer GetById(int customerId)
        {
            string query = @"
                    SELECT 
                        CustomerId,
                        Fullname,
                        Address,
                        ContactNumber,
                        EmploymentStatus,
                        IsActive,
                        CreatedAt
                    FROM Customers
                    WHERE CustomerId = @CustomerId;
            ";

            using(SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@CustomerId", SqlDbType.Int).Value = customerId;

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Customer customer = new Customer()
                            {
                                CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                                Fullname = reader.GetString(reader.GetOrdinal("Fullname")),
                                Address = reader.GetString(reader.GetOrdinal("Address")),
                                ContactNumber = reader.GetString(reader.GetOrdinal("ContactNumber")),

                                EmploymentStatus = reader.IsDBNull(reader.GetOrdinal("EmploymentStatus"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("EmploymentStatus")),

                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };
                            return customer;
                        }
                    }

                }
            }
            return null;
        }
        public void Add(Customer customer)
        {
           if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            string query = @"
                INSERT INTO Customers 
                    (
                        Fullname,
                        Address, 
                        ContactNumber,
                        EmploymentStatus,
                        IsActive
                    )
                OUTPUT INSERTED.CustomerId
                        VALUES
                        (
                            @Fullname,
                            @Address,
                            @ContactNumber,
                            @EmploymentStatus,
                            @IsActive
                        )";

            using(SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Fullname", SqlDbType.NVarChar, 150).Value =
                        customer.Fullname;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar, 255).Value =
                    customer.Address;

                    command.Parameters.Add("@ContactNumber", SqlDbType.VarChar, 20).Value =
                    customer.ContactNumber;


                    command.Parameters.Add("@EmploymentStatus", SqlDbType.NVarChar, 50).Value =
                    (object)customer.EmploymentStatus ?? DBNull.Value;

                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value =
                        customer.IsActive;

                    object newId = command.ExecuteScalar();

                    customer.CustomerId = Convert.ToInt32(newId);

                }
            }
        }
        public void Update(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            string query = @"
        UPDATE Customers
        SET
            FullName = @FullName,
            Address = @Address,
            ContactNumber = @ContactNumber,
            EmploymentStatus = @EmploymentStatus
        WHERE CustomerId = @CustomerId";

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@FullName", SqlDbType.NVarChar, 150).Value =
                        customer.Fullname;

                    command.Parameters.Add("@Address", SqlDbType.NVarChar, 255).Value =
                        customer.Address;

                    command.Parameters.Add("@ContactNumber", SqlDbType.VarChar, 20).Value =
                        customer.ContactNumber;

                    command.Parameters.Add("@EmploymentStatus", SqlDbType.NVarChar, 50).Value =
                        (object)customer.EmploymentStatus ?? DBNull.Value;

                    command.Parameters.Add("@CustomerId", SqlDbType.Int).Value =
                        customer.CustomerId;

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Customer not found.");
                    }
                }
            }
        }
        public void Deactivate(int customerId)
        {
            string query = @"
        UPDATE Customers
        SET IsActive = 0
        WHERE CustomerId = @CustomerId";

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@CustomerId", SqlDbType.Int).Value =
                        customerId;

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Customer not found.");
                    }
                }
            }
        }

    }
}

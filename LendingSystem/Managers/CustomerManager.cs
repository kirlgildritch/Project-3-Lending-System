
using System;
using System.Collections.Generic;
using LendingSystem.Data;
using LendingSystem.Interfaces;
using LendingSystem.Models;

namespace LendingSystem.Managers
{
    public class CustomerManager
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerManager()
        {
            customerRepository = new CustomerRepository();
        }

        public List<Customer> GetAllCustomers()
        {
            return customerRepository.GetAll();
        }

        public Customer GetCustomerById(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentException("Invalid customer ID.");
            }

            return customerRepository.GetById(customerId);
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            if (string.IsNullOrWhiteSpace(customer.FullName))
            {
                throw new ArgumentException("Customer name is required.");
            }

            if (string.IsNullOrWhiteSpace(customer.Address))
            {
                throw new ArgumentException("Customer address is required.");
            }

            if (string.IsNullOrWhiteSpace(customer.ContactNumber))
            {
                throw new ArgumentException("Contact number is required.");
            }

            customerRepository.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            if (customer.CustomerId <= 0)
            {
                throw new ArgumentException("Invalid customer ID.");
            }

            if (string.IsNullOrWhiteSpace(customer.FullName))
            {
                throw new ArgumentException("Customer name is required.");
            }

            if (string.IsNullOrWhiteSpace(customer.Address))
            {
                throw new ArgumentException("Customer address is required.");
            }

            if (string.IsNullOrWhiteSpace(customer.ContactNumber))
            {
                throw new ArgumentException("Contact number is required.");
            }

            customerRepository.Update(customer);
        }

        public void DeactivateCustomer(int customerId)
        {
            if (customerId <= 0)
            {
                throw new ArgumentException("Invalid customer ID.");
            }

            Customer customer = customerRepository.GetById(customerId);

            if (customer == null)
            {
                throw new Exception("Customer does not exist.");
            }

            if (!customer.IsActive)
            {
                throw new Exception("Customer is already inactive.");
            }

            customerRepository.Deactivate(customerId);
        }


    }
}

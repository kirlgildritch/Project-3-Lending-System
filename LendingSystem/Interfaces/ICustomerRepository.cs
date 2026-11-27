using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LendingSystem.Models;

namespace LendingSystem.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();

        Customer GetById(int customerId);

        void Add(Customer customer);

        void Update(Customer customer);

        void Deactivate(int customerId);

    }
}

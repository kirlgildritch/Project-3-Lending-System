using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string EmploymentStatus { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}

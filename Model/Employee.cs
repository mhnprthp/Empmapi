using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Model
{
    public class Employee
    {
         public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

        // Navigation property for Salary
        public ICollection<Salary> Salaries { get; set; }

        // Navigation property for Attachments
        public ICollection<Attachment> Attachments { get; set; }
    }
}
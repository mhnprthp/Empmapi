using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Model
{
    public class Attachment
    {
          public int ID { get; set; }
        public int EmpID { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }

        // Navigation property for Employee
        public Employee Employee { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Dto
{
    public class EmployeeData
    {
        public Employee Employee { get; set; }
    public Salary Salary { get; set; }
    public Attachment Attachment { get; set; }
    }
}
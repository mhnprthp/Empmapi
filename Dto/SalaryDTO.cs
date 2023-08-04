using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Dto
{
    public class SalaryDTO
    {
    public int ID { get; set; }
    public int EmpID { get; set; }
    public decimal Amount { get; set; }
    public bool Annual { get; set; }
    public decimal Bonus { get; set; }
    }
}
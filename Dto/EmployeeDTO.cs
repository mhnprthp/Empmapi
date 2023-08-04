using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Dto
{
    public class EmployeeDTO
    {
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string ContactNo { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    }
}
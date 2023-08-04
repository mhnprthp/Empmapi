using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Dto
{
    public class DetailEmpDTO
    {
         public EmployeeDTO EmployeeDTO { get; set; }
         public SalaryDTO SalaryDTO { get; set; }
         public AttachmentDTO AttachmentDTO { get; set; }
    }
}
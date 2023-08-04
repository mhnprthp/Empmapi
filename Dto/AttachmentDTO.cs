using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Dto
{
    public class AttachmentDTO
    {
    public int ID { get; set; }
    public int EmpID { get; set; }
    public string FileName { get; set; }
    public string FileUrl { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Dto;
using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Service
{
    public interface IEmployeeService 
    {
         Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync(string status, int page, int pageSize);
        int AddEmployee(DetailEmpDTO detailEmpDTO);
        void EditEmployee(int empid, DetailEmpDTO detailEmpDTO);
        Task DeleteEmployeeAsync(int id);
        
          Task<DetailEmpDTO> GetEmpallDetailsByEid(int id);
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementSystem.Dto;
using EmployeeManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _dbContext;

        public EmployeeService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync(string status, int page, int pageSize)
        {
            IQueryable<Employee> query = _dbContext.Employees;

            if (!string.IsNullOrEmpty(status))
            {
                bool isActive = status.ToLower() == "active";
                query = query.Where(e => e.Status == isActive);
            }

            var employees = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return employees.Select(e => new EmployeeDTO
            {
                ID = e.ID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Gender = e.Gender,
                ContactNo = e.ContactNo,
                Email = e.Email,
                Status = e.Status
            });
        }
        public int AddEmployee(DetailEmpDTO detailEmpDTO)
        {
            int empid = 0;
            _dbContext.Database.BeginTransaction();
            try
            {
                Employee empDB = new()
                {
                    FirstName = detailEmpDTO.EmployeeDTO.FirstName,
                    LastName = detailEmpDTO.EmployeeDTO.LastName,
                    Gender = detailEmpDTO.EmployeeDTO.Gender,
                    ContactNo = detailEmpDTO.EmployeeDTO.ContactNo,
                    Email = detailEmpDTO.EmployeeDTO.Email,
                    Status = detailEmpDTO.EmployeeDTO.Status
                };

                _dbContext.Employees.Add(empDB);
                _dbContext.SaveChanges();

                empid = empDB.ID;
                Salary salaryDB = new()
                {
                    EmpID = empid,
                    Amount = detailEmpDTO.SalaryDTO.Amount,
                    Annual = detailEmpDTO.SalaryDTO.Annual,
                    Bonus = detailEmpDTO.SalaryDTO.Bonus
                };
                _dbContext.Salaries.Add(salaryDB);
                _dbContext.SaveChanges();

                Attachment attachmentDB = new()
                {
                    EmpID = empid,
                    FileName = detailEmpDTO.AttachmentDTO.FileName,
                    FileUrl = detailEmpDTO.AttachmentDTO.FileUrl
                };
                _dbContext.Attachments.Add(attachmentDB);
                _dbContext.SaveChanges();

                _dbContext.Database.CommitTransaction();
            }
            catch (System.Exception)
            {
                _dbContext.Database.RollbackTransaction();
                throw;
            }
            return empid;
        }


public void EditEmployee(int empid, DetailEmpDTO detailEmpDTO)
{
    _dbContext.Database.BeginTransaction();
    try
    {
        Employee empDB = _dbContext.Employees.Find(empid);
        if (empDB == null)
        {
            // Employee with the given empid was not found. Handle this as required.
            // For example, throw an exception or return a specific error code.
            // You can also choose to create a new employee record instead.
            throw new ArgumentException("Employee not found", nameof(empid));
        }

        empDB.FirstName = detailEmpDTO.EmployeeDTO.FirstName;
        empDB.LastName = detailEmpDTO.EmployeeDTO.LastName;
        empDB.Gender = detailEmpDTO.EmployeeDTO.Gender;
        empDB.ContactNo = detailEmpDTO.EmployeeDTO.ContactNo;
        empDB.Email = detailEmpDTO.EmployeeDTO.Email;
        empDB.Status = detailEmpDTO.EmployeeDTO.Status;

        Salary salaryDB = _dbContext.Salaries.SingleOrDefault(s => s.EmpID == empid);
        if (salaryDB == null)
        {
            // Salary record not found for the employee. Handle this as required.
            // You can create a new salary record here if needed.
            throw new ArgumentException("Salary record not found", nameof(empid));
        }

        salaryDB.Amount = detailEmpDTO.SalaryDTO.Amount;
        salaryDB.Annual = detailEmpDTO.SalaryDTO.Annual;
        salaryDB.Bonus = detailEmpDTO.SalaryDTO.Bonus;

        Attachment attachmentDB = _dbContext.Attachments.SingleOrDefault(a => a.EmpID == empid);
        if (attachmentDB == null)
        {
            // Attachment record not found for the employee. Handle this as required.
            // You can create a new attachment record here if needed.
            throw new ArgumentException("Attachment record not found", nameof(empid));
        }

        attachmentDB.FileName = detailEmpDTO.AttachmentDTO.FileName;
        attachmentDB.FileUrl = detailEmpDTO.AttachmentDTO.FileUrl;

        _dbContext.SaveChanges();
        _dbContext.Database.CommitTransaction();
    }
    catch (System.Exception)
    {
        _dbContext.Database.RollbackTransaction();
        throw;
    }
}


        public async Task DeleteEmployeeAsync(int id)
        {
            var existingEmployee = await _dbContext.Employees.FindAsync(id);
            if (existingEmployee != null)
            {
                existingEmployee.Status = false; // Soft delete by updating status to inactive
                await _dbContext.SaveChangesAsync();
            }
        }




        public async Task<DetailEmpDTO> GetEmpallDetailsByEid(int id)
        {
            Employee employee = await _dbContext.Employees
          .Where(e => e.ID == id)
          .Include(e => e.Salaries)
          .Include(e => e.Attachments)
          .FirstOrDefaultAsync();

            if (employee == null)
            {
                // Employee not found with the given ID
                return null;
            }

            DetailEmpDTO detailEmpDTO = new()
            {
                EmployeeDTO = new EmployeeDTO
                {
                    ID = employee.ID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Gender = employee.Gender,
                    ContactNo = employee.ContactNo,
                    Email = employee.Email,
                    Status = employee.Status
                },
                SalaryDTO = new SalaryDTO
                {
                    ID = (int)(employee.Salaries.FirstOrDefault()?.ID),
                    EmpID = (int)(employee.Salaries.FirstOrDefault()?.EmpID),
                    Amount = employee.Salaries.FirstOrDefault()?.Amount ?? 0,
                    Annual = employee.Salaries.FirstOrDefault()?.Annual ?? false,
                    Bonus = employee.Salaries.FirstOrDefault()?.Bonus ?? 0
                },
                AttachmentDTO = new AttachmentDTO
                {
                    ID = (int)(employee.Attachments.FirstOrDefault()?.ID),
                    EmpID = (int)(employee.Attachments.FirstOrDefault()?.EmpID),
                    FileName = employee.Attachments.FirstOrDefault()?.FileName,
                    FileUrl = employee.Attachments.FirstOrDefault()?.FileUrl
                }
            };

            return detailEmpDTO;
        }

      
    }
}

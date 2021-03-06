﻿using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    /// <summary>
    /// Interface of Repository Pattern
    /// </summary>
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Get Departments
        /// </summary>
        Task<IEnumerable<Department>> GetDepartments();

        /// <summary>
        /// Get Department
        /// </summary>
        Task<Department> GetDepartment(int departmentId);
    }
}

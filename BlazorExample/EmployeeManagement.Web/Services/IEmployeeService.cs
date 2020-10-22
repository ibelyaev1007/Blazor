using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
    /// <summary>
    /// Interface of Employee Service
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Get all employees via api
        /// </summary>
        Task<IEnumerable<Employee>> GetEmployees();

        /// <summary>
        /// Get employee by id
        /// </summary>
        Task<Employee> GetEmployee(int id);

        /// <summary>
        /// Update Employee
        /// </summary>
        Task<Employee> UpdateEmployee(Employee updatedEmployee);

        /// <summary>
        /// Create Employee
        /// </summary>
        Task<Employee> CreateEmployee(Employee newEmployee);
    }
}

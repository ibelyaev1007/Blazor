using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    /// <summary>
    /// Interface of Repository Pattern
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        Task<IEnumerable<Employee>> GetEmployees();

        /// <summary>
        /// Get employee by id
        /// </summary>
        Task<Employee> GetEmployee(int employeeId);

        /// <summary>
        /// GetEmployee by email
        /// </summary>
        Task<Employee> GetEmployeeByEmail(string email);

        /// <summary>
        /// Add new employee
        /// </summary>
        Task<Employee> AddEmployee(Employee employee);

        /// <summary>
        /// Update employee
        /// </summary>
        Task<Employee> UpdateEmployee(Employee employee);

        /// <summary>
        ///  Delete employee
        /// </summary>
        Task<Employee> DeleteEmployee(int employeeId);
    }
}

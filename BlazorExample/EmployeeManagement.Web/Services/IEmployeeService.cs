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
        /// Get all employees
        /// </summary>
        Task<IEnumerable<Employee>> GetEmployees();
    }
}

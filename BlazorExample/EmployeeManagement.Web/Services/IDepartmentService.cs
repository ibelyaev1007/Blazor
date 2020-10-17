using EmployeeManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    /// <summary>
    /// Interface of Department Service
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// Get departments via api
        /// </summary>
        Task<IEnumerable<Department>> GetDepartments();

        /// <summary>
        /// Get department via api
        /// </summary>
        Task<Department> GetDepartment(int id);
    }
}

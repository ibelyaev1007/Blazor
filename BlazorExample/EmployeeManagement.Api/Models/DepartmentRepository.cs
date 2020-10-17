using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        /// <summary>
        /// DB context, connect in startup method ConfigureServices
        /// </summary>
        private readonly AppDbContext appDbContext;

        /// <summary>
        /// ctor initialize department repository
        /// </summary>
        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <sinheritdoc/>
        public async Task<Department> GetDepartment(int departmentId)
        {
            return await appDbContext.Departments
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        /// <sinheritdoc/>
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync();
        }
    }
}

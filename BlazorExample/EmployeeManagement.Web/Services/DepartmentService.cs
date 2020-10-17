using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        /// <summary>
        /// Http client
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Ctor initialize http client
        /// </summary>
        public DepartmentService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        /// <sinheritdoc/>
        public async Task<Department> GetDepartment(int id)
        {
            return await _httpClient.GetJsonAsync<Department>($"api/departments/{id}");
        }

        /// <sinheritdoc/>
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _httpClient.GetJsonAsync<Department[]>("api/departments");
        }
    }
}

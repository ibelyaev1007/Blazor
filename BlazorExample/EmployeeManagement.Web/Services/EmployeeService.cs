﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// Http client
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Ctor initialize http client
        /// </summary>
        public EmployeeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        /// <sinheritdoc/>
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _httpClient.GetJsonAsync<Employee[]>("api/employees");
        }

        /// <sinheritdoc/>
        public async Task<Employee> GetEmployee(int id)
        {
            return await _httpClient.GetJsonAsync<Employee>($"api/employees/{id}");
        }

        /// <sinheritdoc/>
        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            return await _httpClient.PutJsonAsync<Employee>("api/employees", updatedEmployee);
        }

        /// <sinheritdoc/>
        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            return await _httpClient.PostJsonAsync<Employee>("api/employees", newEmployee);
        }

        /// <sinheritdoc/>
        public async Task DeleteEmployee(int id)
        {
            await _httpClient.DeleteAsync($"api/employees/{id}");
        }
    }
}

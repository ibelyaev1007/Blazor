using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        /// <summary>
        /// Gets, sets employee
        /// </summary>
        public Employee Employee { get; set; } = new Employee();

        /// <summary>
        /// Employee Service
        /// use [Inject] attribute to inject a service into a Blazor component.
        /// </summary>
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        /// <summary>
        /// Department Service
        /// use [Inject] attribute to inject a service into a Blazor component.
        /// </summary>
        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        /// <summary>
        /// Gets, sets Id 
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <summary>
        /// Gets, sets Departments 
        /// </summary>
        public List<Department> Departments { get; set; } = new List<Department>();

        /// <sinheritdoc/>
        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();
        }
    }
}
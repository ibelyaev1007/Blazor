using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        /// <summary>
        /// Gets, sets employees
        /// </summary>
        public Employee Employee { get; set; } = new Employee();

        /// <summary>
        /// Employee Service
        /// use [Inject] attribute to inject a service into a Blazor component.
        /// </summary>
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        /// <summary>
        /// Id
        /// (Id) matches with the name of the route parameter in the @page directive (@page "/employeedetails/{Id}")
        /// </summary>
        [Parameter]
        public string Id { get; set; }

        /// <sinheritdoc/>
        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }
    }
}

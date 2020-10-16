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
        /// Gets, sets Id 
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
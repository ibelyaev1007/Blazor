using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        /// <summary>
        /// Gets sets Employee Service
        /// </summary>
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        /// <summary>
        /// Gets sets Navigation Manager
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Gets sets Employee
        /// </summary>
        [Parameter]
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets sets Show Footer
        /// </summary>
        [Parameter]
        public bool ShowFooter { get; set; }

        /// <summary>
        /// Employee Selection callback
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        /// <summary>
        /// Employee Deleted callback
        /// </summary>
        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        /// <summary>
        /// Gets sets is selected
        /// </summary>
        protected bool IsSelected { get; set; }

        /// <summary>
        /// Check Box Changed handling
        /// </summary>
        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            IsSelected = (bool)e.Value;
            await OnEmployeeSelection.InvokeAsync(IsSelected);
        }

        /// <summary>
        /// Delete button click
        /// </summary>
        protected async Task Delete_Click()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            // Possible update page, but lost scroll position
            //NavigationManager.NavigateTo("/", true);
        }
    }
}

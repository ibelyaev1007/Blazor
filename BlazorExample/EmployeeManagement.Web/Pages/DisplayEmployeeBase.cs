using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using RazorComponents;

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

        protected ConfirmBase DeleteConfirmation { get; set; }

        /// <summary>
        /// Delete button click
        /// </summary>
        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            }
        }

        /// <summary>
        /// Delete button click without dialog
        /// </summary>
        //protected async Task Delete_Click()
        //{
        //    await EmployeeService.DeleteEmployee(Employee.EmployeeId);
        //    await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
        //    // Possible update page, but lost scroll position
        //    //NavigationManager.NavigateTo("/", true);
        //}
    }
}

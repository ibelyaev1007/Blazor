using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
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
    }
}

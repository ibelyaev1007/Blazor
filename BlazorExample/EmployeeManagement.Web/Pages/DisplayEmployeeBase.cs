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
    }
}

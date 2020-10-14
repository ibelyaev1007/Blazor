using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

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
        /// Gets, sets Coordinates
        /// </summary>
        protected string Coordinates { get; set; }

        /// <summary>
        /// Button Text
        /// </summary>
        protected string ButtonText { get; set; } = "Hide Footer";

        /// <summary>
        /// Css Class
        /// </summary>
        protected string CssClass { get; set; } = null;

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

        /// <summary>
        /// Button Click handler
        /// </summary>
        protected void Button_Click()
        {
            if (ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide Footer";
            }
        }
    }
}

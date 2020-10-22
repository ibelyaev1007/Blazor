using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        /// <summary>
        /// Gets, sets employee
        /// </summary>
        private Employee Employee { get; set; } = new Employee();

        /// <summary>
        /// Gets, sets edit employee model
        /// </summary>
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

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
        /// Auto Mapper
        /// use [Inject] attribute to inject a service into a Blazor component.
        /// </summary>
        [Inject]
        public IMapper Mapper { get; set; }

        /// <summary>
        /// Navigation Manager
        /// use [Inject] attribute to inject a service into a Blazor component.
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }

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


            Mapper.Map(Employee, EditEmployeeModel);
            // Mapper.Map do operation below
            //EditEmployeeModel.EmployeeId = Employee.EmployeeId;
            //EditEmployeeModel.FirstName = Employee.FirstName;
            //EditEmployeeModel.LastName = Employee.LastName;
            //EditEmployeeModel.Email = Employee.Email;
            //EditEmployeeModel.ConfirmEmail = Employee.Email;
            //EditEmployeeModel.DateOfBrith = Employee.DateOfBrith;
            //EditEmployeeModel.Gender = Employee.Gender;
            //EditEmployeeModel.PhotoPath = Employee.PhotoPath;
            //EditEmployeeModel.DepartmentId = Employee.DepartmentId;
            //EditEmployeeModel.Department = Employee.Department;
        }

        /// <summary>
        /// Handle valid Submit from form
        /// </summary>
        protected async void HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);
            var result = await EmployeeService.UpdateEmployee(Employee);
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
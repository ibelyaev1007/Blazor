using AutoMapper;
using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Models
{
    /// <summary>
    /// Contains the mapping profiles for AutoMapper
    /// </summary>   
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            /// <summary>
            /// Create map Employee to EditEmployeeModel
            /// NOTE:
            /// For ConfirmEmail property in EditEmployeeModel class, we do not have a matching property in Employee class. 
            /// We have an explicit mapping to map the Email property in Employee class to ConfirmEmail property in EditEmployeeModel class.          
            /// </summary> 
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(dest => dest.ConfirmEmail,
                           opt => opt.MapFrom(src => src.Email));

            /// <summary>
            /// Create map EditEmployeeModel EditEmployeeModel to Employee
            /// </summary> 
            CreateMap<EditEmployeeModel, Employee>();
        }
    }
}

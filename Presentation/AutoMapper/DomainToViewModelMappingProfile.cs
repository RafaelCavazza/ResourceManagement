using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels.Employee;

namespace Presentation.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Employee, CreateEmployeeViewModel>();
            CreateMap<Employee, EditEmployeeViewModel>();
        }
    }
}

using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels.Branch;
using Presentation.ViewModels.Employee;

namespace Presentation.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateEmployeeViewModel, Employee>().ForMember(x => x.Branch, opt => opt.Ignore());
            CreateMap<EditEmployeeViewModel, Employee>().ForMember(x => x.Branch, opt => opt.Ignore());

            CreateMap<CreateBranchViewModel, Branch>().ForMember(x => x.Employees, opt => opt.Ignore());
            CreateMap<EditBranchViewModel, Branch>().ForMember(x => x.Employees, opt => opt.Ignore());
        }
    }
}

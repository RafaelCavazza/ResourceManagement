using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels.Branch;
using Presentation.ViewModels.Employee;
using Presentation.ViewModels.Item;

namespace Presentation.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Employee, CreateEmployeeViewModel>().ForMember(x => x.Branch, opt => opt.Ignore());
            CreateMap<Employee, DetailsEmployeeViewModel>().ForMember(x => x.Branch, opt => opt.Ignore());
            CreateMap<Employee, EditEmployeeViewModel>().ForMember(x => x.Branch, opt => opt.Ignore());

            CreateMap<Branch, CreateBranchViewModel>();
            CreateMap<Branch, DetailsBranchViewModel>();
            CreateMap<Branch, EditBranchViewModel>();

            CreateMap<Item, CreateItemViewModel>().ForMember(x => x.Products, opt => opt.Ignore());
        }
    }
}

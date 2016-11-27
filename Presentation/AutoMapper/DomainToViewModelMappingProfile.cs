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
            //Employee
            CreateMap<Employee, CreateEmployeeViewModel>().ForMember(x => x.Branch, opt => opt.Ignore());
            CreateMap<Employee, DetailsEmployeeViewModel>().ForMember(x => x.Branch, opt => opt.Ignore());
            CreateMap<Employee, EditEmployeeViewModel>().ForMember(x => x.Branch, opt => opt.Ignore());

            //Branch
            CreateMap<Branch, CreateBranchViewModel>();
            CreateMap<Branch, DetailsBranchViewModel>();
            CreateMap<Branch, EditBranchViewModel>();

            //Item
            CreateMap<Item, CreateItemViewModel>().ForMember(x => x.Products, opt => opt.Ignore());
            CreateMap<Item, CreateItemViewModel>().ForMember(x => x.Itens, opt => opt.Ignore());
            CreateMap<Item, EditItemViewModel>();
        }
    }
}

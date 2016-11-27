using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels.Branch;
using Presentation.ViewModels.Employee;
using Presentation.ViewModels.Item;
using Presentation.ViewModels.Product;

namespace Presentation.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Employee
            CreateMap<CreateEmployeeViewModel, Employee>().ForMember(x => x.Branch, opt => opt.Ignore());
            CreateMap<EditEmployeeViewModel, Employee>().ForMember(x => x.Branch, opt => opt.Ignore());

            //Branch
            CreateMap<CreateBranchViewModel, Branch>().ForMember(x => x.Employees, opt => opt.Ignore());
            CreateMap<EditBranchViewModel, Branch>().ForMember(x => x.Employees, opt => opt.Ignore());

            //Product
            CreateMap<ProductViewModel, Product>();
            CreateMap<EditProductViewModel, Product>();

            //Item
            CreateMap<CreateItemViewModel, Item>().ForMember(x => x.Product, opt => opt.Ignore());
            CreateMap<EditItemViewModel, Item>().ForMember(x => x.Product, opt => opt.Ignore());
        }
    }
}

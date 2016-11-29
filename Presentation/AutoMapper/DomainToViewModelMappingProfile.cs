using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels.Branch;
using Presentation.ViewModels.Employee;
using Presentation.ViewModels.Item;
using Presentation.ViewModels.Product;
using Presentation.ViewModels.Loan;

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

            //Product
            CreateMap<Product, EditProductViewModel>();
            CreateMap<Product, ProductViewModel>()
            .ForSourceMember(x => x.CreatedOn , opt => opt.Ignore())
            .ForSourceMember(x => x.ModifiedOn , opt => opt.Ignore());

            //Item
            CreateMap<Item, CreateItemViewModel>().ForMember(x => x.Products, opt => opt.Ignore());
            CreateMap<Item, CreateItemViewModel>().ForMember(x => x.Itens, opt => opt.Ignore());
            CreateMap<Item, EditItemViewModel>();

            //Loan
            CreateMap<Loan, LoanViewModel>()
            .ForMember(l => l.Employee, lw => lw.MapFrom( m => m.Employee.Name))
            .ForMember(l => l.Product, lw => lw.MapFrom( m => m.Item.Product.Name))
            .ForMember(l => l.Patrimonio, lw => lw.MapFrom( m => m.Item.Patrimonio));
        }
    }
}

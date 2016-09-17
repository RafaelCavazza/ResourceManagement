using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Presentation.ViewModels.Employee;

namespace Presentation.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateEmployeeViewModel, Employee>();
            CreateMap<EditEmployeeViewModel, Employee>();
        }

        public override string ProfileName
        {
            get{ return "ViewModelToDomainMappingProfile"; }
        }
    }
}

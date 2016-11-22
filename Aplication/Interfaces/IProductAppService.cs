using System;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Aplication.Interfaces
{
    public interface IProductAppService : IAppServiceBase<Product>
    {
    }
}
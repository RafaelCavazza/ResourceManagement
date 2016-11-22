using Aplication.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Aplication
{
    public class ProductAppService  : AppServiceBase<Product>, IProductAppService
    {
        public readonly IProductService _productService;
        public ProductAppService(IProductService productService) : base(productService)
        {
            _productService = productService;
        }
    }
}

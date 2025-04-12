using AutoMapper;
using Ecommerce.WebApi.Features.Products.UpdateProduct;
using Ecommerce.Application.Products.UpdateProduct;

namespace Ecommerce.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductProfile : Profile
    {
        public UpdateProductProfile()
        {
            CreateMap<UpdateProductRequest, UpdateProductCommand>();
            CreateMap<UpdateProductResult, UpdateProductResponse>();
        }
    }
}

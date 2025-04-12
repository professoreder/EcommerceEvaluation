using Ecommerce.Application.Products.GetProduct;
using AutoMapper;

namespace Ecommerce.WebApi.Features.Products.GetProduct;

public class GetProductProfile : Profile
{
    public GetProductProfile()
    {
        CreateMap<GetProductRequest, GetProductCommand>();
        CreateMap<GetProductResult, GetProductResponse>();
    }
}

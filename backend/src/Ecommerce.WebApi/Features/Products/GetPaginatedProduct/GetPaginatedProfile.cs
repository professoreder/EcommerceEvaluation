using Ecommerce.Application.Products.GetPaginatedProduct;
using AutoMapper;

namespace Ecommerce.WebApi.Features.Products.GetPaginatedProduct;

public class GetPaginatedProfile : Profile
{
    public GetPaginatedProfile()
    {
        CreateMap<GetPaginatedProductRequest, GetPaginatedProductCommand>();
        CreateMap<GetPaginatedProductResult, GetPaginatedProductResponse>();
    }
}

using Ecommerce.Application.Products.DeleteProduct;
using AutoMapper;

namespace Ecommerce.WebApi.Features.Products.DeleteProduct;

public class DeleteProductProfile : Profile
{
    public DeleteProductProfile()
    {
        CreateMap<DeleteProductRequest, DeleteProductCommand>();
    }
}

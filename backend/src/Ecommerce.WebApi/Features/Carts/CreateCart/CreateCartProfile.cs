using AutoMapper;
using Ecommerce.Application.Carts.CreateCart;
using Ecommerce.WebApi.Features.Carts.CreateCart;

namespace Ecommerce.WebApi.Features.Carts.CreateCart;

public class CreateCartProfile : Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartRequest, CreateCartCommand>();
        CreateMap<CreateCartRequestItem, CreateCartItemDto>();
    }
}

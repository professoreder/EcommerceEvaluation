using AutoMapper;
using Ecommerce.Application.Carts.UpdateCart;
using Ecommerce.Domain.Entities;
using Ecommerce.WebApi.Features.Carts.UpdateCart;

namespace Ecommerce.WebApi.Features.Carts.UpdateCart;

public class UpdateCartProfile : Profile
{
    public UpdateCartProfile()
    {
        CreateMap<UpdateCartRequest, UpdateCartCommand>();
        CreateMap<UpdateCartRequestItem, UpdateCartItemDto>();
    }
}

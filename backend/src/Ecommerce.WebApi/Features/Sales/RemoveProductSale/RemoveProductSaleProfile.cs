using Ecommerce.Application.Sales.RemoveProductSale;
using AutoMapper;

namespace Ecommerce.WebApi.Features.Sales.RemoveProductSale;

public class RemoveProductSaleProfile : Profile
{
    public RemoveProductSaleProfile()
    {
        CreateMap<RemoveProductSaleRequest, RemoveProductSaleCommand>();
    }
}
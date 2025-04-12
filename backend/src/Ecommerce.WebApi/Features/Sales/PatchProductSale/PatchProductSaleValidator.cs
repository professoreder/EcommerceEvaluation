using Ecommerce.Application.Sales.PatchProductSale;
using AutoMapper;


namespace Ecommerce.WebApi.Features.Sales.PatchProductSale;

public class PatchProductSaleValidator : Profile
{
    public PatchProductSaleValidator()
    {
        CreateMap<PatchProductSaleRequest, PatchProductSaleCommand>();
    }
}

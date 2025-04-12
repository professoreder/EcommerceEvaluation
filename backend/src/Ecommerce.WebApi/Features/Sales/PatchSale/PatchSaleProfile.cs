
using Ecommerce.Application.Sales.PatchSale;
using AutoMapper;

namespace Ecommerce.WebApi.Features.Sales.PatchSale;

public class PatchSaleProfile : Profile
{
    public PatchSaleProfile()
    {
        CreateMap<PatchSaleRequest, PatchSaleCommand>();
    }
}

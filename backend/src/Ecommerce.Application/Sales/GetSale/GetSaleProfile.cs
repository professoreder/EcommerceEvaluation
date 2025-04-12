using AutoMapper;
using SaleEntity = Ecommerce.Domain.Entities.Sale;

namespace Ecommerce.Application.Sales.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<SaleEntity, GetSaleResult>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductSales));
    }
}

using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Entities;
using AutoMapper;

namespace Ecommerce.Application.Sales.GetPaginatedSales;

public class GetPaginatedProfile : Profile
{
    public GetPaginatedProfile()
    {
        CreateMap<Sale, GetPaginatedSaleResult>()
            .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(dest => dest.ProductSales.Count()));
        CreateMap<GetPaginatedSalesCommand, GetPaginatedSaleDto>();
    }
}

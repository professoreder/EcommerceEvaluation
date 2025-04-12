using Ecommerce.Application.Sales.GetPaginatedSales;
using AutoMapper;

namespace Ecommerce.WebApi.Features.Sales.GetPaginatedSale;

public class PaginatedSaleProfile : Profile
{
    public PaginatedSaleProfile()
    {
        CreateMap<GetPaginatedSaleRequest, GetPaginatedSalesCommand>();
        CreateMap<GetPaginatedSaleResult, GetPaginatedSaleResponse>();
    }
}

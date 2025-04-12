using Ecommerce.Application.Sales.DeleteSale;
using AutoMapper;

namespace Ecommerce.WebApi.Features.Sales.DeleteSale;

public class DeleteSaleRequest
{
    public Guid Id { get; internal set; }
}
public class DeleteSaleValidator : Profile
{
    public DeleteSaleValidator()
    {
        CreateMap<DeleteSaleRequest, DeleteSaleCommand>();
    }
}

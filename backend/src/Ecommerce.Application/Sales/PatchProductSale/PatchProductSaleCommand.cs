using Ecommerce.Domain.Dtos;
using MediatR;

namespace Ecommerce.Application.Sales.PatchProductSale;

public class PatchProductSaleCommand : IRequest<bool>
{
    public Guid Id { get; internal set; }

    public IEnumerable<ProductRequestDto> Products { get; set; } = [];
}

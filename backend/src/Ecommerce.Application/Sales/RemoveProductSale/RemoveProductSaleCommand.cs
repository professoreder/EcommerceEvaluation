using MediatR;

namespace Ecommerce.Application.Sales.RemoveProductSale;

public class RemoveProductSaleCommand : IRequest<bool>
{
    public Guid Id { get; internal set; }
    public IEnumerable<Guid> Products { get; set; } = [];
}

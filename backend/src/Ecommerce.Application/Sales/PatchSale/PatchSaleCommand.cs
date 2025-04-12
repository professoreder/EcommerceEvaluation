using MediatR;

namespace Ecommerce.Application.Sales.PatchSale;

public class PatchSaleCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

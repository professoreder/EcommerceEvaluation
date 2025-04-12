using MediatR;

namespace Ecommerce.Application.Sales.DeleteSale;

public class DeleteSaleCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

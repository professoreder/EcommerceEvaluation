using Ecommerce.Domain.Dtos;
using MediatR;

namespace Ecommerce.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public IEnumerable<ProductRequestDto> Products { get; set; } = [];
}

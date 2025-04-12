using MediatR;

namespace Ecommerce.Application.Carts.UpdateCart;

public class UpdateCartCommand : IRequest<bool>
{
    public Guid UserId { get; set; }
    public List<UpdateCartItemDto> Items { get; set; } = new();
}

public class UpdateCartItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

namespace Ecommerce.WebApi.Features.Carts.CreateCart;

public class CreateCartRequest
{
    public Guid UserId { get; set; }
    public List<CreateCartRequestItem> Items { get; set; } = new();
}

public class CreateCartRequestItem
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

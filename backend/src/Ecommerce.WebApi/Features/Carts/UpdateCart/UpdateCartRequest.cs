namespace Ecommerce.WebApi.Features.Carts.UpdateCart;

public class UpdateCartRequest
{
    public Guid UserId { get; set; }
    public List<UpdateCartRequestItem> Items { get; set; } = new();
}

public class UpdateCartRequestItem
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

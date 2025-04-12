using MediatR;

namespace Ecommerce.Application.Products.UpdateProduct;

public class UpdateProductCommand : IRequest<UpdateProductResult>
{
    /// <summary>
    /// Gets the product id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets the product name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product price.
    /// </summary>
    public decimal Price { get; set; }
}

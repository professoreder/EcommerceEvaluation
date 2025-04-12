namespace Ecommerce.Application.Products.UpdateProduct;

public class UpdateProductResult
{
    /// <summary>
    /// Gets the product Id
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
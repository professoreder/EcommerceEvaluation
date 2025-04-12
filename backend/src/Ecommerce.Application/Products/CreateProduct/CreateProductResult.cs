﻿namespace Ecommerce.Application.Products.CreateProduct;

public class CreateProductResult
{
    public Guid Id { get; set; }
    /// <summary>
    /// Gets the product name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets the product quantity.
    /// </summary>
    public int Quantity { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WebApi.Features.Products.UpdateProduct
{
    /// <summary>
    /// response when a existing product is updated
    /// </summary>
    public class UpdateProductResponse
    {
        /// <summary>
        /// Product id
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets the product name.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets the product price.
        /// </summary>
        [Required]
        public decimal Price { get; set; }
    }
}

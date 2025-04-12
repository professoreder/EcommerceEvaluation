using Ecommerce.Common.Validation;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Validation;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Domain.Entities;

public class Sale : BaseEntity
{
    /// <summary>
    /// Gets the sale number.
    /// Sequence number by the system to identify the sale.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Gets the date and time when the sale was made.
    /// use the time zone utc to save the date
    /// </summary>
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; } = null;

    /// <summary>
    /// Gets the total value of the sale.
    /// must be calculated based on the sum of the products in the sale.
    /// </summary>
    public decimal TotalValue { get; set; }

    /// <summary>
    /// gets the sale.status
    /// </summary>
    public SaleStatus Status { get; set; } = SaleStatus.Active;

    public Guid UserId { get; set; }

    public User? User { get; set; }

    /// <summary>
    /// Performs validation of the <see cref="Sale" /> entity using the<see cref="SaleValidator"/> rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">ProductSales existence</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Gets the products in the sale.
    /// </summary>
    public ICollection<ProductSale> ProductSales { get; set; } = [];

    /// <summary>
    /// Gets the total value of the sale.
    /// </summary>
    public void CalculateTotalValue()
    {
        ProductSales.ToList().ForEach(p => p.CalculateTotalAmount());
        TotalValue = ProductSales
            .Where(p => p.Status != SaleStatus.Canceled)
            .Sum(p => p.TotalAmout);
    }
}
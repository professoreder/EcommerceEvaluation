using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.Events;

public class PatchSaleEvent
{
    public SaleStatus Status { get; set; }
    public Guid Id { get; set; }
}

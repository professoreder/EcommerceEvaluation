using Ecommerce.Domain.Events;
using Rebus.Handlers;
using Serilog;

namespace Ecommerce.Application.Sales.PatchSale;

public class PatchSaleEventHandler : IHandleMessages<PatchSaleEvent>
{
    public Task Handle(PatchSaleEvent message)
    {
        Log.Information("PatchSale event received: {@Message}", message);
        return Task.CompletedTask;
    }
}

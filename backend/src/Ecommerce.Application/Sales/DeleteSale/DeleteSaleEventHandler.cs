using Ecommerce.Domain.Events;
using Rebus.Handlers;
using Serilog;

namespace Ecommerce.Application.Sales.DeleteSale;

public class DeleteSaleEventHandler : IHandleMessages<DeleteSaleEvent>
{
    public Task Handle(DeleteSaleEvent message)
    {
        Log.Information("DeleteSale event received: {@Message}", message);
        return Task.CompletedTask;
    }
}

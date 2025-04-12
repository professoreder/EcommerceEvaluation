using Ecommerce.Domain.Events;
using Ecommerce.Domain.Repositories;
using MediatR;
using Rebus.Bus;

namespace Ecommerce.Application.Sales.DeleteSale;

public class DeleteSaleCommandHandler : IRequestHandler<DeleteSaleCommand, bool>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IBus _bus;

    public DeleteSaleCommandHandler(ISaleRepository saleRepository, IBus bus)
    {
        _saleRepository = saleRepository;
        _bus = bus;
    }

    public DeleteSaleCommandHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<bool> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var result = await _saleRepository.DeleteAsync(request.Id, cancellationToken);

        if (_bus != null)
            await _bus.Send(new DeleteSaleEvent() { Id = request.Id });

        return result;
    }
}

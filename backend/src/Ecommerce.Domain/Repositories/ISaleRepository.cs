using Ecommerce.Domain.Common;
using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Repositories;

public interface ISaleRepository
{
    Task<Sale?> CreateAsync(Sale sale, CancellationToken cancellationToken = default);
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<PaginatedList<Sale>> GetAsync(GetPaginatedSaleDto request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Sale?> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);
}
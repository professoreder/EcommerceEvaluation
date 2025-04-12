using Ecommerce.Domain.Common;
using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Product>> GetManyById(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);
    Task<PaginatedList<Product>> GetPaginatedProducts(GetPaginatedProductDto dto, CancellationToken cancellationToken = default);
}

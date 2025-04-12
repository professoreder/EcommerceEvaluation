using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Ecommerce.Infrastructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly IMongoCollection<Cart> _collection;

    public CartRepository(IConfiguration configuration)
    {
        var connectionString = configuration["MongoDbSettings:ConnectionString"];
        var databaseName = configuration["MongoDbSettings:Database"];
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);

        _collection = database.GetCollection<Cart>("Carts");
    }

    public async Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _collection.Find(c => c.UserId == userId).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<Cart>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(cart, cancellationToken: cancellationToken);
        return cart;
    }

    public async Task<bool> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        cart.UpdatedAt = DateTime.UtcNow;
        var existing = await _collection.Find(c => c.UserId == cart.UserId).FirstOrDefaultAsync(cancellationToken);
        if (existing == null) return false;

        // tentar reaproveitar o Id real
        cart.Id = existing.Id;

        var result = await _collection.ReplaceOneAsync(
            c => c.UserId == cart.UserId,
            cart,
            new ReplaceOptions { IsUpsert = false },
            cancellationToken);

        return result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var result = await _collection.DeleteOneAsync(c => c.UserId == userId, cancellationToken);
        return result.DeletedCount > 0;
    }
}

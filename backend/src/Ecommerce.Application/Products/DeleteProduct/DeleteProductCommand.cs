﻿using Ecommerce.Domain.Repositories;
using MediatR;

namespace Ecommerce.Application.Products.DeleteProduct;

public class DeleteProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return await _productRepository.DeleteAsync(request.Id, cancellationToken);
    }
}
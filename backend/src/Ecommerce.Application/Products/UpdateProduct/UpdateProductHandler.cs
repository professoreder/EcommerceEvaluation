using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Repositories;
using AutoMapper;
using MediatR;
using Ecommerce.Application.Products.CreateProduct;

namespace Ecommerce.Application.Products.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);

        await _productRepository.UpdateAsync(product, cancellationToken);

        var result = _mapper.Map<UpdateProductResult>(product);

        return result;
    }
}

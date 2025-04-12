﻿using Ecommerce.Domain.Common;
using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ecommerce.Application.Sales.GetPaginatedSales;

public class GetPaginatedSaleHandler : IRequestHandler<GetPaginatedSalesCommand, PaginatedList<GetPaginatedSaleResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetPaginatedSaleHandler(ISaleRepository saleRepository, IMapper mappper)
    {
        _saleRepository = saleRepository;
        _mapper = mappper;
    }

    public async Task<PaginatedList<GetPaginatedSaleResult>> Handle(GetPaginatedSalesCommand request, CancellationToken cancellationToken)
    {
        var dto = _mapper.Map<GetPaginatedSaleDto>(request);

        var sales = await _saleRepository.GetAsync(dto, cancellationToken);

        var result = _mapper.Map<PaginatedList<GetPaginatedSaleResult>>(sales);

        return result;
    }
}

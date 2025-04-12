﻿using Ecommerce.Application.Sales.DeleteSale;
using Ecommerce.Domain.Repositories;
using Ecommerce.Unit.Domain.Entities.TestData;
using NSubstitute;
using Xunit;

namespace Ecommerce.Unit.Application;

public class DeleteSaleHandlerTest
{
    private readonly DeleteSaleCommandHandler _handler;
    private readonly ISaleRepository _saleRepository;
    public DeleteSaleHandlerTest()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _handler = new DeleteSaleCommandHandler(_saleRepository);
    }

    [Fact]
    public async Task Should_Cancel_A_Valid_Sale()
    {

        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        _saleRepository.DeleteAsync(sale.Id, default).Returns(true);

        var request = new DeleteSaleCommand { Id = sale.Id };
        // Act
        var result = await _handler.Handle(request, default);
        // Assert
        Assert.True(result);
    }
}
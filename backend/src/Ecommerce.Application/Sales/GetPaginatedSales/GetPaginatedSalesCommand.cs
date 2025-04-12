using Ecommerce.Application.Common;
using Ecommerce.Domain.Common;
using MediatR;

namespace Ecommerce.Application.Sales.GetPaginatedSales;

public class GetPaginatedSalesCommand : PaginatedCommand, IRequest<PaginatedList<GetPaginatedSaleResult>>
{
}

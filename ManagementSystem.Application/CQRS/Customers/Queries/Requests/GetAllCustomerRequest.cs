using ManagementSystem.Application.CQRS.Customers.Queries.Responses;
using ManagementSystem.Common.GlobalResponses;
using ManagementSystem.Common.GlobalResponses.Generics;
using MediatR;

namespace ManagementSystem.Application.CQRS.Customers.Queries.Requests;

public class GetAllCustomerRequest:IRequest<ResultPagination<GetAllCustomerResponse>>
{
    public int Limit { get; set; } = 10;
    public int Page { get; set; } = 1;
}

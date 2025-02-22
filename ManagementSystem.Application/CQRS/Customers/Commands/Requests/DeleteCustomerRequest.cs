using ManagementSystem.Common.GlobalResponses;
using ManagementSystem.Common.GlobalResponses.Generics;
using MediatR;

namespace ManagementSystem.Application.CQRS.Customers.Commands.Requests;

public class DeleteCustomerRequest:IRequest<Result<Unit>>
{
    public int Id { get; set; }
}

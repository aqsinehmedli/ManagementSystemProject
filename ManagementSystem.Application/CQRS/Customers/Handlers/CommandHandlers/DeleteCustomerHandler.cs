using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Repository.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ManagementSystem.Application.CQRS.Customers.Handlers.CommandHandlers;

public class DeleteCustomerHandler
{
    public class Handler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCustomerRequest, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Result<Unit>> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.Delete(request.Id,1);
            return new Result<Unit> { Errors = [],IsSuccess=true };
        }
    }

}

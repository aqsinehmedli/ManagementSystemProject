using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using ManagementSystem.Application.CQRS.Customers.Commands.Responses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Customers.Handlers.CommandHandlers;

public class CreateCustomerHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCustomerRequest, Result<CreateCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<CreateCustomerResponse>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        Customer newCustomer = new()
        {
            Name = request.Name,
            Email = request.Email,  
        };  
        if (string.IsNullOrEmpty(newCustomer.Name))
        {
            return new Result<CreateCustomerResponse>
            {
                Data = null,
                Errors = ["Customerin ad-i null ve ya bos ola bilmez"],
                IsSuccess = false
            };
        }
        await _unitOfWork.CustomerRepository.AddAsync(newCustomer);
        CreateCustomerResponse response = new()
        {
            Id = newCustomer.Id,
            Name = newCustomer.Name,
            Email = newCustomer.Email,
        };
        return new Result<CreateCustomerResponse>
        {
            Data = response,
            Errors = [],
            IsSuccess = true
        };
    }
}

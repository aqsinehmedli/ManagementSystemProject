using AutoMapper;
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
    private readonly IMapper _mapper;
    public async Task<Result<CreateCustomerResponse>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
    var newCustomer = _mapper.Map<Customer>(request);
        if ((string.IsNullOrEmpty(newCustomer.Name) || string.IsNullOrEmpty(newCustomer.Email))) 
        {
            return new Result<CreateCustomerResponse>
            {
                Data = null,
                Errors = ["Customerin ad-i ve ya email null ve ya bos ola bilmez"],
                IsSuccess = false
            };
        }
        await _unitOfWork.CustomerRepository.AddAsync(newCustomer);
        var response = _mapper.Map<CreateCustomerResponse>(newCustomer);
        return new Result<CreateCustomerResponse>
        {
            Data = response,
            Errors = [],
            IsSuccess = true
        };
    }
}

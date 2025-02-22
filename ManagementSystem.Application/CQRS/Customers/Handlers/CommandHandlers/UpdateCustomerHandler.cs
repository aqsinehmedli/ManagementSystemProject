using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using ManagementSystem.Application.CQRS.Customers.Commands.Responses;
using ManagementSystem.Common.GlobalResponses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Customers.Handlers.CommandHandlers;

public class UpdateCustomerHandler
{
    public class Handler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCustomerRequest, Result<UpdateCustomerResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<UpdateCustomerResponse>> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
            if (customer == null)
            {
                return new Result<UpdateCustomerResponse>
                {
                    Data = null,
                    Errors = ["Musteri tapilmadi"],
                    IsSuccess = false
                };
            }
            customer.Id = request.Id;
            customer.Name = request.Name;   
            customer.Email = request.Email;
             _unitOfWork.CustomerRepository.Update(customer);
            var response = new UpdateCustomerResponse
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
            };
            return new Result<UpdateCustomerResponse>
            {
                Data = response,
                Errors = [],
                IsSuccess = true
            };
        }
    }

}
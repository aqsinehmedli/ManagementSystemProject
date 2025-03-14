﻿using AutoMapper;
using ManagementSystem.Application.CQRS.Customers.Commands.Requests;
using ManagementSystem.Application.CQRS.Customers.Commands.Responses;
using ManagementSystem.Common.GlobalResponses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Customers.Handlers.CommandHandlers;

public class UpdateCustomerHandler
{
    public class Handler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateCustomerRequest, Result<UpdateCustomerResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
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

            var response = _mapper.Map<UpdateCustomerResponse>(customer);
            return new Result<UpdateCustomerResponse>
            {
                Data = response,
                Errors = [],
                IsSuccess = true
            };
        }
    }

}
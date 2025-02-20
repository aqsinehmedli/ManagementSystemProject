using ManagementSystem.Application.CQRS.Customers.Queries.Requests;
using ManagementSystem.Application.CQRS.Customers.Queries.Responses;
using ManagementSystem.Common.GlobalResponses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Customers.Handlers.Responses.QueryHandlers;


public class GetAllCategoryQuery(IUnitOfWork unitOfWork) : IRequestHandler<GetAllCustomerRequest, ResultPagination<GetAllCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ResultPagination<GetAllCustomerResponse>> Handle(GetAllCustomerRequest request, CancellationToken cancellationToken)
    {
        var customers = _unitOfWork.CustomerRepository.GetAll();
        var totalCount = customers.Count();
        customers = customers.Skip((request.Page - 1) * request.Limit).Take(request.Limit);
        var mappedCustomer = new List<GetAllCustomerResponse>();
        foreach (var customer in customers)
        {
            var mapped = new GetAllCustomerResponse()
            {
                Id = customer.Id,
                Name = customer.Name,
                CreatedBy = customer.CreatedBy,
                CreatedDate = customer.CreatedDate,
            };
            mappedCustomer.Add(mapped);
        }
        return new ResultPagination<GetAllCustomerResponse>
        {
            Data = new Pagination<GetAllCustomerResponse> { Data = mappedCustomer, TotalDataCount = totalCount, IsSuccess = true }
        };
    }
}


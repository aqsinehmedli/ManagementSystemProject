﻿namespace ManagementSystem.Application.CQRS.Customers.Queries.Responses;

public class GetAllCustomerResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? CreatedBy { get; set; }

}

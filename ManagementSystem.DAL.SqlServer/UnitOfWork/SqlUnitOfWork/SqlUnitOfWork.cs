using ManagementSystem.DAL.SqlServer.Context;
using ManagementSystem.DAL.SqlServer.Infrastructure;
using ManagementSystem.Repository.Common;
using ManagementSystem.Repository.Repositories;

namespace ManagementSystem.DAL.SqlServer.UnitOfWork.SqlUnitOfWork;

public class SqlUnitOfWork(string connectionString, AppDbContext context) : IUnitOfWork
{
    private readonly string _connectionString = connectionString;
    private readonly AppDbContext _context = context;
    public SqlCustomerRepository _sqlCustomerRepository;
    public ICustomerRepository CustomerRepository => _sqlCustomerRepository ?? new SqlCustomerRepository(connectionString, _context);
}

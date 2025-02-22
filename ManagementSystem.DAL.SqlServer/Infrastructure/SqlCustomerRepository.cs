using Dapper;
using ManagementSystem.DAL.SqlServer.Context;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Repository.Repositories;

namespace ManagementSystem.DAL.SqlServer.Infrastructure;

public class SqlCustomerRepository : BaseSqlRepository, ICustomerRepository
{
    private readonly AppDbContext _context;
    public SqlCustomerRepository(string connectionString, AppDbContext context) : base(connectionString)
    {
        _context = context;
    }

    public async Task AddAsync(Customer customer)
    {
        var sql = @"INSERT INTO Customers ([Name],[CreatedBy])
                    VALUES(@Name,@CreatedBy); SELECT SCOPE_IDENTITY()";
        using var connection = OpenConnection();
        var generatedId = await connection.ExecuteScalarAsync<int>(sql, customer);
        customer.Id = generatedId;  
    }

    public async Task<bool> Delete(int id, int deletedBy)
    {
        var checkSql = @"SELECT Id FROM Customers WHERE Id = @id and IsDeleted=0";
        var sql = $@"UPDATE Customers
                    SET isDeleted = 1,
                    DeletedBy = @deletedBy,
                    DeletedDate = GETDATE(),
                    WHERE Id = @id";
        using var connection = OpenConnection();
        using var transaction = connection.BeginTransaction();
        var customerId = await connection.ExecuteScalarAsync<int?>(checkSql, new { id }, transaction);

        if (!customerId.HasValue)
        {
            return false;
        }
        var affectedRow = await connection.ExecuteAsync(sql, new { id, deletedBy }, transaction);
        transaction.Commit();
        return affectedRow > 0;
    }

    public IQueryable<Customer> GetAll()
    {
        return _context.Customers.OrderByDescending(c => c.CreatedDate).Where(c => c.IsDeleted == false);
    }
    public async Task<IEnumerable<Customer>> GetAllInitialDataAsync()
    {
        var sql = @"SELECT C.[Id],C[Name]
                    FROM Customers AS C
                    WHERE IsDeleted = 0";
        using var connection = OpenConnection();
        return await connection.QueryAsync<Customer>(sql, connection);
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        var sql = @"SELECT C.* FROM Customers WHERE C.Id=@id and C.IsDeleted=0";
        using var connection = OpenConnection();
        return await connection.QueryFirstOrDefaultAsync<Customer>(sql, new { id });
    }

    public void Update(Customer customer)
    {
        var sql = @"UPDATE Customers
                    SET Name = @Name
                    UpdatedBy = @UpdatedBy
                    UpdateDate = @GETDATE()
                    WHERE Id = @id";
        using var connection = OpenConnection();
        connection.Query(sql, customer);
    }
}

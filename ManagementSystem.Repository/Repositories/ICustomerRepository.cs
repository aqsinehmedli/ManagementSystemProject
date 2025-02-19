using ManagementSystem.Domain.Entities;

namespace ManagementSystem.Repository.Repositories;

//IQuerable - IQueryable, verilənlər üzərində sorğular yazmağa imkan verən bir interfeysdır. Bu interfeys, LINQ sorğularının işlədilməsini təmin edir. IQueryable, verilənlərin yaddaşda (memory) deyil, əsasən verilənlər bazasında və ya uzaq mənbələrdə sorğulanması üçün istifadə olunur.
public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
    void Update(Customer customer);
    Task<bool> Delete(int id,int deletedBy);
    IQueryable<Customer> GetAll();
    Task<Customer> GetByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllInitialDataAsync();
}

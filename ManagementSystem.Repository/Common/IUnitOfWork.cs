using ManagementSystem.Repository.Repositories;

namespace ManagementSystem.Repository.Common;

//IUnitOfWork - bizim tranzaksiyalarimiizi bir ad altinda topluyub burda yazirig ve program cs de yalnizca IUnitOfWOrk - u qeydiyyatdan keciririk.
//Butun repositorilere catmag olur.
public interface IUnitOfWork
{
    public ICustomerRepository CustomerRepository { get;}
}

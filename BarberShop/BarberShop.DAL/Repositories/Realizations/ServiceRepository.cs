using BarberShop.DAL.Entities;
using BarberShop.DAL.Persistence;
using BarberShop.DAL.Repositories.Interfaces;
using BarberShop.DAL.Repositories.Realizations.Base;

namespace BarberShop.DAL.Repositories.Realizations;

public class ServiceRepository: RepositoryBase<Service>, IServiceRepository
{
    public ServiceRepository(BarberShopDbContext dbContext)
        : base(dbContext)
    {
    }
}

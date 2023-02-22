using BarberShop.DAL.Entities;
using BarberShop.DAL.Persistence;
using BarberShop.DAL.Repositories.Interfaces;
using BarberShop.DAL.Repositories.Realizations.Base;

namespace BarberShop.DAL.Repositories.Realizations;

public class UserRepository: RepositoryBase<User>, IUserRepository
{
    public UserRepository(BarberShopDbContext dbContext)
        : base(dbContext)
    {
    }
}

using BarberShop.DAL.Entities;
using BarberShop.DAL.Persistence;
using BarberShop.DAL.Repositories.Interfaces;
using BarberShop.DAL.Repositories.Realizations.Base;

namespace BarberShop.DAL.Repositories.Realizations;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(BarberShopDbContext dbContext)
        : base(dbContext)
    {
    }
}

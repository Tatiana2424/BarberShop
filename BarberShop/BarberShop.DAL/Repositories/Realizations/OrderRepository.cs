using BarberShop.DAL.Entities;
using BarberShop.DAL.Persistence;
using BarberShop.DAL.Repositories.Interfaces;
using BarberShop.DAL.Repositories.Realizations.Base;

namespace BarberShop.DAL.Repositories.Realizations;

public class OrderController: RepositoryBase<Order>, IOrderRepository
{
    public OrderController(BarberShopDbContext dbContext)
        : base(dbContext)
    {
    }
}

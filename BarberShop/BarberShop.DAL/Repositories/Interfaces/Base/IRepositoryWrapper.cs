
namespace BarberShop.DAL.Repositories.Interfaces.Base;

public interface IRepositoryWrapper
{
    IBarberRepository BarberRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IOrderRepository OrderRepository { get; }
    IPlaceRepository PlaceRepository { get; }
    IServiceRepository ServiceRepository { get; }
    IStatusRepository StatusRepository { get; }
    IUserRepository UserRepository { get; }

    public int SaveChanges();

    public Task<int> SaveChangesAsync();
}
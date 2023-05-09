using BarberShop.DAL.Persistence;
using BarberShop.DAL.Repositories.Interfaces;
using BarberShop.DAL.Repositories.Interfaces.Base;

namespace BarberShop.DAL.Repositories.Realizations.Base;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly BarberShopDbContext _barberShopDbContext;

    private IBarberRepository _barberRepository;

    private ICategoryRepository _categoryRepository;

    private IOrderRepository _orderRepository;

    private IServiceRepository _serviceRepository;

    private IStatusRepository _statusRepository;

    private IUserRepository _userRepository;

    public RepositoryWrapper(BarberShopDbContext barberShopDbContext)
    {
        _barberShopDbContext = barberShopDbContext;
    }

    public IBarberRepository BarberRepository 
    { 
        get 
        {
            if (_barberRepository is null)
            {
                _barberRepository = new BarberRepository(_barberShopDbContext);
            }
            return _barberRepository; 
        } 
    }
    public ICategoryRepository CategoryRepository
    {
        get
        {
            if (_categoryRepository is null)
            {
                _categoryRepository = new CategoryRepository(_barberShopDbContext);
            }
            return _categoryRepository;
        }
    }
    public IOrderRepository OrderRepository
    {
        get
        {
            if (_orderRepository is null)
            {
                _orderRepository = new OrderRepository(_barberShopDbContext);
            }
            return _orderRepository;
        }
    }
  
    public IServiceRepository ServiceRepository
    {
        get
        {
            if (_serviceRepository is null)
            {
                _serviceRepository = new ServiceRepository(_barberShopDbContext);
            }
            return _serviceRepository;
        }
    }
    public IStatusRepository StatusRepository
    {
        get
        {
            if (_statusRepository is null)
            {
                _statusRepository = new StatusRepository(_barberShopDbContext);
            }
            return _statusRepository;
        }
    }
    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository is null)
            {
                _userRepository = new UserRepository(_barberShopDbContext);
            }
            return _userRepository;
        }
    }

    public int SaveChanges()
    {
        return _barberShopDbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _barberShopDbContext.SaveChangesAsync();
    }

}
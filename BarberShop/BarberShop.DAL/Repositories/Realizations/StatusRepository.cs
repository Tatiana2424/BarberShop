using BarberShop.DAL.Entities;
using BarberShop.DAL.Persistence;
using BarberShop.DAL.Repositories.Interfaces;
using BarberShop.DAL.Repositories.Realizations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.DAL.Repositories.Realizations;

public class StatusRepository: RepositoryBase<Status>, IStatusRepository
{
    public StatusRepository(BarberShopDbContext dbContext)
        : base(dbContext)
    {
    }
}

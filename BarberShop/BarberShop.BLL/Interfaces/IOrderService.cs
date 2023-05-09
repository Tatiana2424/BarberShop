using BarberShop.BLL.DTO;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.BLL.Interfaces;

public interface IOrderService
{
    public Task<Result<List<TimeSpan>>> GetByBarberIdArrayOfFreeTime(int sumTime, string date, int barberId);
}

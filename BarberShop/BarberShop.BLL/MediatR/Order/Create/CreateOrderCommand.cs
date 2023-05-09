using BarberShop.BLL.DTO;
using FluentResults;
using MediatR;
using System.Collections.Generic;

namespace BarberShop.BLL.MediatR.Order.Create
{
    public class CreateOrderCommand : IRequest<Result<List<OrderDTO>>>
    {
        public List<OrderDTO> Orders { get; set; }
    }
}

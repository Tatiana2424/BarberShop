using BarberShop.BLL.DTO;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Order.GetAll;

public record GetAllOrdersQuery : IRequest<Result<IEnumerable<OrderDTO>>>;

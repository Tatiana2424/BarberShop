using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Service.Delete;

public record DeleteServiceCommand(int Id) : IRequest<Result<Unit>>;
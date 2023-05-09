using BarberShop.BLL.DTO;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Service.Update;

public record UpdateServiceCommand(ServiceDTO Service) : IRequest<Result<Unit>>;
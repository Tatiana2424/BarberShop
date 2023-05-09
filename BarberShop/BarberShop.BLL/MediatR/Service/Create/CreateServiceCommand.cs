using BarberShop.BLL.DTO;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Service.Create;

public record CreateServiceCommand(ServiceDTO Service) : IRequest<Result<Unit>>;
using BarberShop.BLL.DTO;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Service.GetById;

public record GetServiceByIdQuery(int Id) : IRequest<Result<ServiceDTO>>;

using BarberShop.BLL.DTO;
using BarberShop.DAL.Entities;
using FluentResults;
using Hangfire.Storage.Monitoring;
using MediatR;

namespace BarberShop.BLL.MediatR.Service.GetAll;

public record GetAllServicesQuery : IRequest<Result<IEnumerable<ServiceDTO>>>;

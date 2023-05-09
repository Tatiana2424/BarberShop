using AutoMapper;
using BarberShop.BLL.DTO;
using BarberShop.BLL.MediatR.Category.GetAll;
using BarberShop.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace BarberShop.BLL.MediatR.Order.GetAll;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, Result<IEnumerable<OrderDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetAllOrdersHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<OrderDTO>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _repositoryWrapper
            .OrderRepository
            .GetAllAsync();

        if (orders is null)
        {
            return Result.Fail(new Error($"Cannot find any orders"));
        }

        var ordersDtos = _mapper.Map<IEnumerable<OrderDTO>>(orders);
        return Result.Ok(ordersDtos);
    }
}

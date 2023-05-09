using AutoMapper;
using BarberShop.BLL.DTO;
using BarberShop.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BarberShop.BLL.MediatR.Order.Create
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result<List<OrderDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CreateOrderHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<Result<List<OrderDTO>>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var results = new List<Result<OrderDTO>>();

            foreach (var orderDto in request.Orders)
            {
                var order = _mapper.Map<BarberShop.DAL.Entities.Order>(orderDto);

                if (order is null)
                {
                    results.Add(Result.Fail<OrderDTO>(new Error("Cannot convert null to order")));
                }
                else
                {
                    _repositoryWrapper.OrderRepository.Create(order);
                    var resultIsSuccess = await _repositoryWrapper.SaveChangesAsync() > 0;
                    var result = resultIsSuccess ? Result.Ok(_mapper.Map<OrderDTO>(order)) : Result.Fail<OrderDTO>(new Error("Failed to create an order"));
                    results.Add(result);
                }
            }

            if (results.Any(r => r.IsFailed))
            {
                var errors = results.Where(r => r.IsFailed).SelectMany(r => r.Errors);
                return Result.Fail<List<OrderDTO>>(errors);
            }

            var createdOrders = results.Select(r => r.Value).ToList();

            return Result.Ok(createdOrders);
        }
    }
}

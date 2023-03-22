using AutoMapper;
using BarberShop.BLL.DTO;
using BarberShop.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Service.GetAll;

public class GetAllServicesHandler : IRequestHandler<GetAllServicesQuery, Result<IEnumerable<ServiceDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetAllServicesHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ServiceDTO>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        var services = await _repositoryWrapper.ServiceRepository.GetAllAsync();

        if (services is null)
        {
            return Result.Fail(new Error($"Cannot find any services"));
        }

        var servicesDtos = _mapper.Map<IEnumerable<ServiceDTO>>(services);
        return Result.Ok(servicesDtos);
    }
}

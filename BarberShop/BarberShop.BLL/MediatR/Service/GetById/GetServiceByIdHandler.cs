using AutoMapper;
using BarberShop.BLL.DTO;
using BarberShop.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace BarberShop.BLL.MediatR.Service.GetById;

public class GetServiceByIdHandler : IRequestHandler<GetServiceByIdQuery, Result<ServiceDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetServiceByIdHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<ServiceDTO>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var service = await _repositoryWrapper
            .ServiceRepository.GetSingleOrDefaultAsync(s => s.Id == request.Id);


        if (service is null)
        {
            return Result.Fail(new Error($"Cannot find any service with corresponding id: {request.Id}"));
        }

        var partnerDto = _mapper.Map<ServiceDTO>(service);
        return Result.Ok(partnerDto);
    }
}
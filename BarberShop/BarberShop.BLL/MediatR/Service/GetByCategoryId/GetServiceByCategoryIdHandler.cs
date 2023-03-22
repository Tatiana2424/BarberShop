using AutoMapper;
using BarberShop.BLL.DTO;
using BarberShop.BLL.MediatR.Service.GetById;
using BarberShop.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.BLL.MediatR.Service.GetByCategoryId;

public class GetServiceByCategoryIdHandler : IRequestHandler<GetServiceByCategoryIdQuery, Result<IEnumerable<ServiceDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetServiceByCategoryIdHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ServiceDTO>>> Handle(GetServiceByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var service = await _repositoryWrapper
            .ServiceRepository.GetAllAsync(
                predicate: text => text.CategoryId == request.CatrgoryId,
                include: scl => scl.Include(sc => sc.Image)!);


        if (service is null)
        {
            return Result.Fail(new Error($"Cannot find any service with corresponding id: {request.CatrgoryId}"));
        }

        var partnerDto = _mapper.Map<IEnumerable<ServiceDTO>>(service);
        return Result.Ok(partnerDto);
    }
}

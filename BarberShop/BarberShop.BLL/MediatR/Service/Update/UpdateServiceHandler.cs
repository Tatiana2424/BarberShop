﻿using AutoMapper;
using BarberShop.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Service.Update;

public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand, Result<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public UpdateServiceHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = _mapper.Map<DAL.Entities.Service>(request.Service);

        if (service is null)
        {
            return Result.Fail(new Error("Cannot convert null to service"));
        }

        _repositoryWrapper.ServiceRepository.Update(service);

        var resultIsSuccess = await _repositoryWrapper.SaveChangesAsync() > 0;
        return resultIsSuccess ? Result.Ok(Unit.Value) : Result.Fail(new Error("Failed to update a service"));
    }
}
using BarberShop.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Service.Delete;

public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, Result<Unit>>
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public DeleteServiceHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Result<Unit>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _repositoryWrapper.ServiceRepository.GetFirstOrDefaultAsync(f => f.Id == request.Id);

        if (service is null)
        {
            return Result.Fail(new Error($"Cannot find a service with id : {request.Id}"));
        }

        _repositoryWrapper.ServiceRepository.Delete(service);

        var resultIsSuccess = await _repositoryWrapper.SaveChangesAsync() > 0;
        return resultIsSuccess ? Result.Ok(Unit.Value) : Result.Fail(new Error("Failed to delete a service"));
    }
}
using BarberShop.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Category.Delete;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Result<Unit>>
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public DeleteCategoryHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Result<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repositoryWrapper.CategoryRepository.GetFirstOrDefaultAsync(f => f.Id == request.Id);

        if (category is null)
        {
            return Result.Fail(new Error($"Cannot find a category with id : {request.Id}"));
        }

        _repositoryWrapper.CategoryRepository.Delete(category);

        var resultIsSuccess = await _repositoryWrapper.SaveChangesAsync() > 0;
        return resultIsSuccess ? Result.Ok(Unit.Value) : Result.Fail(new Error("Failed to delete a category"));
    }
}
using AutoMapper;
using BarberShop.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Category.Create;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Result<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public CreateCategoryHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<DAL.Entities.Category>(request.Category);

        if (category is null)
        {
            return Result.Fail(new Error("Cannot convert null to category"));
        }

        _repositoryWrapper.CategoryRepository.Create(category);

        var resultIsSuccess = await _repositoryWrapper.SaveChangesAsync() > 0;

        return resultIsSuccess ? Result.Ok(Unit.Value) : Result.Fail(new Error("Failed to create a category"));
    }
}
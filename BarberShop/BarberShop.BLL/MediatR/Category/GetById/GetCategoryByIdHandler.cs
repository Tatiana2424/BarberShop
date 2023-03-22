using AutoMapper;
using BarberShop.BLL.DTO;
using BarberShop.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;


namespace BarberShop.BLL.MediatR.Category.GetById;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetCategoryByIdHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<CategoryDTO>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _repositoryWrapper
            .CategoryRepository
            .GetSingleOrDefaultAsync(c => c.Id == request.Id);

        if (category is null)
        {
            return Result.Fail(new Error($"Cannot find any category with corresponding id: {request.Id}"));
        }

        var categoryDto = _mapper.Map<CategoryDTO>(category);
        return Result.Ok(categoryDto);
    }
}
using AutoMapper;
using BarberShop.BLL.DTO;
using BarberShop.DAL.Repositories.Interfaces.Base;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace BarberShop.BLL.MediatR.Category.GetAll;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, Result<IEnumerable<CategoryDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public GetAllCategoriesHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
    {
        _repositoryWrapper = repositoryWrapper;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<CategoryDTO>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repositoryWrapper
            .CategoryRepository
            .GetAllAsync(
                include: scl => scl.Include(sc => sc.Image)!);

        if (categories is null)
        {
            return Result.Fail(new Error($"Cannot find any categories"));
        }

        var categoryDtos = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        return Result.Ok(categoryDtos);
    }
}

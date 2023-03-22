using BarberShop.BLL.DTO;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Category.GetAll;

public record GetAllCategoriesQuery : IRequest<Result<IEnumerable<CategoryDTO>>>;

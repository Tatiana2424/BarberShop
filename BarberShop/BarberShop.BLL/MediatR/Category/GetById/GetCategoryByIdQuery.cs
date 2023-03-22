using BarberShop.BLL.DTO;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Category.GetById;

public record GetCategoryByIdQuery(int Id) : IRequest<Result<CategoryDTO>>;

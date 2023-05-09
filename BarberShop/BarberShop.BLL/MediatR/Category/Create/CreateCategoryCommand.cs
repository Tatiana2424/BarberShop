using BarberShop.BLL.DTO;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Category.Create;

public record CreateCategoryCommand(CategoryDTO Category) : IRequest<Result<Unit>>;
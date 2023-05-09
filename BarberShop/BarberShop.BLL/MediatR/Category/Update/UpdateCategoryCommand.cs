using BarberShop.BLL.DTO;
using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Category.Update;

public record UpdateCategoryCommand(CategoryDTO Category) : IRequest<Result<Unit>>;
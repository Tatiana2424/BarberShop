using FluentResults;
using MediatR;

namespace BarberShop.BLL.MediatR.Category.Delete;

public record DeleteCategoryCommand(int Id) : IRequest<Result<Unit>>;
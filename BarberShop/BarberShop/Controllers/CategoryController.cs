using BarberShop.BLL.MediatR.Category;
using BarberShop.BLL.MediatR.Category.GetAll;
using BarberShop.BLL.MediatR.Category.GetById;
using BarberShop.WebApi.Controllers.BaseController;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.WebApi.Controllers;


public class CategoryController  : BaseApiController
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await Mediator.Send(new GetAllCategoriesQuery()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new GetCategoryByIdQuery(id)));
    }
}

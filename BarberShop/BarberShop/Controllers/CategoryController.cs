using BarberShop.BLL.DTO;
using BarberShop.BLL.MediatR.Category.Create;
using BarberShop.BLL.MediatR.Category.Delete;
using BarberShop.BLL.MediatR.Category.GetAll;
using BarberShop.BLL.MediatR.Category.GetById;
using BarberShop.BLL.MediatR.Category.Update;
using BarberShop.DAL.Entities;
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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryDTO Category)
    {
        return HandleResult(await Mediator.Send(new CreateCategoryCommand(Category)));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryDTO Category)
    {
        Category.Id = id;
        return HandleResult(await Mediator.Send(new UpdateCategoryCommand(Category)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new DeleteCategoryCommand(id)));
    }
}

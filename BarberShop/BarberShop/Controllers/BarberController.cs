using BarberShop.BLL.DTO;
using BarberShop.BLL.MediatR.Barber.Create;
using BarberShop.BLL.MediatR.Barber.Delete;
using BarberShop.BLL.MediatR.Barber.GetAll;
using BarberShop.BLL.MediatR.Barber.GetById;
using BarberShop.BLL.MediatR.Barber.Update;
using BarberShop.BLL.MediatR.Category.GetAll;
using BarberShop.BLL.MediatR.Category.GetById;
using BarberShop.WebApi.Controllers.BaseController;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.WebApi.Controllers;

public class BarberController : BaseApiController
{
    private readonly IMediator _mediator;
    public BarberController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await Mediator.Send(new GetAllBarbersQuery()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new GetBarberByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BarberDTO Barber)
    {
        return HandleResult(await Mediator.Send(new CreateBarberCommand(Barber)));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BarberDTO Barber)
    {
        Barber.Id = id;
        return HandleResult(await Mediator.Send(new UpdateBarberCommand(Barber)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new DeleteBarberCommand(id)));
    }
}

using BarberShop.BLL.DTO;
using BarberShop.BLL.MediatR.Service.Create;
using BarberShop.BLL.MediatR.Service.Delete;
using BarberShop.BLL.MediatR.Service.GetAll;
using BarberShop.BLL.MediatR.Service.GetByCategoryId;
using BarberShop.BLL.MediatR.Service.GetById;
using BarberShop.BLL.MediatR.Service.Update;
using BarberShop.WebApi.Controllers.BaseController;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.WebApi.Controllers;

public class ServiceController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await Mediator.Send(new GetAllServicesQuery()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new GetServiceByIdQuery(id)));
    }

    [HttpGet("{categoryId:int}")]
    public async Task<IActionResult> GetByCategoryId([FromRoute] int categoryId)
    {
        return HandleResult(await Mediator.Send(new GetServiceByCategoryIdQuery(categoryId)));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ServiceDTO Service)
    {
        return HandleResult(await Mediator.Send(new CreateServiceCommand(Service)));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ServiceDTO Service)
    {
        Service.Id = id;
        return HandleResult(await Mediator.Send(new UpdateServiceCommand(Service)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return HandleResult(await Mediator.Send(new DeleteServiceCommand(id)));
    }
}

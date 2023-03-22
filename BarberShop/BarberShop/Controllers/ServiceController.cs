using BarberShop.BLL.MediatR.Category.GetAll;
using BarberShop.BLL.MediatR.Category.GetById;
using BarberShop.BLL.MediatR.Service.GetAll;
using BarberShop.BLL.MediatR.Service.GetByCategoryId;
using BarberShop.BLL.MediatR.Service.GetById;
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
}

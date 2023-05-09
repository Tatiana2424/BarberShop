using BarberShop.BLL.DTO;
using BarberShop.BLL.Interfaces;
using BarberShop.BLL.MediatR.Order.Create;
using BarberShop.BLL.MediatR.Order.GetAll;
using BarberShop.WebApi.Controllers.BaseController;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.WebApi.Controllers;

public class OrderController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IOrderService _orderService;
    public OrderController(IMediator mediator, IOrderService orderService)
    {
        _mediator = mediator;
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return HandleResult(await Mediator.Send(new GetAllOrdersQuery()));
    }
    //[HttpPost]
    //public async Task<IActionResult> Create(CreateOrderCommand command)
    //{
    //    var result = await _mediator.Send(command);

    //    if (result.IsFailed)
    //    {
    //        return BadRequest(result.Errors);
    //    }

    //    return Ok(result.Value);
    //}
    [HttpPost]
    public async Task<IActionResult> CreateOrders(List<OrderDTO> orderDTOs)
    {
        var createOrderCommand = new CreateOrderCommand { Orders = orderDTOs };
        var result = await _mediator.Send(createOrderCommand);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.Errors);
    }

    [HttpGet("{barberId:int}/{sumTime:int}/{date}")]
    public async Task<IActionResult> GetByBarberIdArrayOfFreeTime([FromRoute] int barberId, int sumTime, string date)
    {
        var result = await _orderService.GetByBarberIdArrayOfFreeTime(sumTime, date, barberId);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        else
        {
            return BadRequest(result.Value);
        }
       
    }
}
//public async Task<ActionResult> Create([FromBody] OrderDTO request)
//{
//    var createOrderCommand = new CreateOrderCommand { Orders = request. };
//    var result = await _mediator.Send(createOrderCommand);

//    if (result.IsSuccess)
//    {
//        return Ok();
//    }

//    return BadRequest(result.Errors);
//}






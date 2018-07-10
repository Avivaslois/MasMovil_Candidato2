using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.ControllerWorkers;
using Order.Domain.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderCW _orderCW;

        public OrdersController(IOrderCW orderCW)
        {
            _orderCW = orderCW;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] OrderDto order)
        {
            await _orderCW.procesarPedido(order);
            return "ok";
            
        }

    }
}

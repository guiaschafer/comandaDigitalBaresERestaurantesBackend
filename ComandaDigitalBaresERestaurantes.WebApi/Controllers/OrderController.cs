using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using Microsoft.AspNetCore.Mvc;

namespace ComandaDigitalBaresERestaurantes.WebApi.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderProvider orderProvider;
        public OrderController(IOrderProvider orderProvider)
        {
            this.orderProvider = orderProvider;
        }
        [HttpPost]
        [Route("orderConfirm")]
        public IActionResult OrderConfirm(ICollection<OrderDto> orderItens)
        {
            var userLogin = User.Claims.FirstOrDefault(c => c.Type == "User").Value;
            return Ok();
        }
    }
}

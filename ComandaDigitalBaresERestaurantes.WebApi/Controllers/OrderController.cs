using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult OrderConfirm([FromBody]  List<OrderDto> orderItens)
        {
            try
            {
                var userLogin = User.Claims.LastOrDefault(c => c.Type == ClaimTypes.Name).Value;

                orderProvider.ConfirmOrder(orderItens, userLogin);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        [Route("confirmPayment")]
        [Authorize]
        public IActionResult OrderConfirm([FromBody] PaymentDto payment)
        {
            try
            {
                orderProvider.ConfirmPayment(payment);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet]
        [Route("orders")]
        [Authorize]
        public IActionResult Orders()
        {
            try
            {
                var userLogin = User.Claims.LastOrDefault(c => c.Type == ClaimTypes.Name).Value;
                                
                return Ok(orderProvider.GetAllOrders(userLogin));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}

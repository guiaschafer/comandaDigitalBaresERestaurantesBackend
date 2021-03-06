﻿using System;
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
                return BadRequest("Não foi possível confirmar o pedido");
            }

        }

        [HttpPost]
        [Route("confirmPayment")]
        [Authorize]
        public IActionResult ConfirmPayment([FromBody] PaymentDto payment)
        {
            try
            {
                var x = orderProvider.ConfirmPayment(payment).Result;
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

        [HttpGet]
        [Route("ordersKitchen")]
        [Authorize]
        public IActionResult OrdersKitchen()
        {
            try
            {
                return Ok(orderProvider.GetAllOrders(Aplicacao.Domain.Enum.Perfil.Kitchen));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("ordersBarBartender")]
        [Authorize]
        public IActionResult OrdersBarBartender()
        {
            try
            {
                return Ok(orderProvider.GetAllOrders(Aplicacao.Domain.Enum.Perfil.Bar));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("ordersAll")]
        [Authorize]
        public IActionResult OrdersAll()
        {
            try
            {
                return Ok(orderProvider.GetAllOrders());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        [Route("updateStatusOrder")]
        [Authorize]
        public IActionResult UpdateStatusOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                orderProvider.UpdateStatusOrder(orderDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}

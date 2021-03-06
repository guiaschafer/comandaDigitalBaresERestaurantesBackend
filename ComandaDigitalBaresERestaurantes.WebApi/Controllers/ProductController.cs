﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComandaDigitalBaresERestaurantes.WebApi.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductProvider productProvider;
        public ProductController(IProductProvider productProvider)
        {
            this.productProvider = productProvider;
        }

        [HttpGet]
        [Authorize]
        [Route("products")]
        public IActionResult Index()
        {
            try
            {
                var produtos = productProvider.GetAll();
                return Ok(produtos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("products")]
        public IActionResult ProductInsert([FromBody] ProductDto productDto)
        {
            try
            {
                productProvider.Insert(productDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("products")]
        public IActionResult ProductUpdate([FromBody] ProductDto productDto)
        {
            try
            {
                productProvider.Update(productDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

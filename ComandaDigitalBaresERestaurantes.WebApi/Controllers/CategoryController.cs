using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComandaDigitalBaresERestaurantes.WebApi.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryProvider categoryProvider;
        public CategoryController(ICategoryProvider categoryProvider)
        {
            this.categoryProvider = categoryProvider;
        }

        [Authorize]
        [HttpGet]
        [Route("categories")]
        public IActionResult Categories()
        {
            try
            {
                var categories = categoryProvider.GetAll();
                return Ok(categories);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("categories")]
        public IActionResult CategoriesInsert([FromBody] CategoryDto categoryDto)
        {
            try
            {
                categoryProvider.Insert(categoryDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("categories")]
        public IActionResult CategoriesUpdate([FromBody] CategoryDto categoryDto)
        {
            try
            {
                categoryProvider.Update(categoryDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

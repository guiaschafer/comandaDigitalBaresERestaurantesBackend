using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
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
    }
}

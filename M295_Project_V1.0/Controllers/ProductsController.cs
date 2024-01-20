using M295_Project_V1._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace M295_Project_V1._0.Controllers
{
    [Route("api/products")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductAppContext _context;

        public ProductsController(ProductAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Products);
        }

        [HttpGet]
        [Route("{id}")] // GET /api/products/1
        public IActionResult Get(long id)
        {
            return  Ok(_context.Products.Where((prod) => prod.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Product added successfully" });
            }

            return BadRequest(ModelState);
        }



    }
}


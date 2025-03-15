using Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test : ControllerBase

    {
        private readonly ApplicationDbContext _context;

        public Test(ApplicationDbContext context) // Inject DbContext
        {
            this._context = context;
        }

        //[Authorize(Roles ="Admin")]
        //[HttpGet]
        //public IActionResult GetPublicData()
        //{
        //    Product testProduct = new Product
        //    {
        //        Id = 12,
        //        Name = "Shirt"
        //    };
        //    return Ok(testProduct);
        //}

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok("added to db");

        }
    }
}

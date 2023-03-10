using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using Infrastructure.Data;
using Core.Entities;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetPRoduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
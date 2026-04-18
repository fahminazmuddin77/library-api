using Microsoft.AspNetCore.Mvc;
using Dapper;
using LibraryAPI.Data;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly DbContext _context;

        public CategoriesController(DbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            using var connection = _context.CreateConnection();
            var data = connection.Query("SELECT * FROM categories");

            return Ok(new { status = "success", data });
        }
    }
}
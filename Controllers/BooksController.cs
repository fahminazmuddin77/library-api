using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;
using LibraryAPI.Data;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly DbContext _context;

        public BooksController(DbContext context)
        {
            _context = context;
        }

        // GET ALL (JOIN)
        [HttpGet]
        public IActionResult GetAll()
        {
            using var connection = _context.CreateConnection();

            var query = @"
                SELECT 
                    b.id,
                    b.title,
                    b.author,
                    c.name AS category,
                    u.name AS user_name
                FROM books b
                JOIN categories c ON b.category_id = c.id
                JOIN users u ON b.user_id = u.id
            ";

            var data = connection.Query(query);

            return Ok(new { status = "success", data });
        }

        // GET BY ID (JOIN)
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using var connection = _context.CreateConnection();

            var query = @"
                SELECT 
                    b.id,
                    b.title,
                    b.author,
                    c.name AS category,
                    u.name AS user_name
                FROM books b
                JOIN categories c ON b.category_id = c.id
                JOIN users u ON b.user_id = u.id
                WHERE b.id = @id
            ";

            var data = connection.QueryFirstOrDefault(query, new { id });

            if (data == null)
                return NotFound(new { status = "error", message = "Data not found" });

            return Ok(new { status = "success", data });
        }

        // CREATE
        [HttpPost]
        public IActionResult Create(Book book)
        {
            using var connection = _context.CreateConnection();

            var query = @"
                INSERT INTO books (title, author, category_id, user_id)
                VALUES (@Title, @Author, @Category_Id, @User_Id)
            ";

            connection.Execute(query, book);

            return Ok(new { status = "success", message = "Book created" });
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            using var connection = _context.CreateConnection();

            var query = @"
                UPDATE books 
                SET title=@Title, author=@Author, category_id=@Category_Id, user_id=@User_Id
                WHERE id=@id
            ";

            var result = connection.Execute(query, new
            {
                book.Title,
                book.Author,
                book.Category_Id,
                book.User_Id,
                id
            });

            if (result == 0)
                return NotFound(new { status = "error", message = "Data not found" });

            return Ok(new { status = "success", message = "Updated" });
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using var connection = _context.CreateConnection();

            var result = connection.Execute(
                "DELETE FROM books WHERE id=@id", new { id });

            if (result == 0)
                return NotFound(new { status = "error", message = "Data not found" });

            return Ok(new { status = "success", message = "Deleted" });
        }
    }
}
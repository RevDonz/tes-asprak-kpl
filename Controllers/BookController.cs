using Microsoft.AspNetCore.Mvc;

namespace TesAsprak.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>()
        {
            new Book("Harry Potter", 123, "Orang"),
            new Book("Game Of Thrones", 123, "Orang juga")
        };

        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBooks")]
        public dynamic Get()
        {
           return Book.ReadData();
        }

        

        [HttpGet("{id}")]
        public dynamic Get(int id)
        {
            return Book.ReadData()[id];
        }

        [HttpPost]
        public void Post([FromBody] Book book)
        {
            books.Add(book);
        }

        [HttpPut("{id}")]
        public Book PUT([FromBody] int id, string name, string writer)
        {
            books[id].Name = name;
            books[id].Writer = writer;

            return books[id];
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            books.RemoveAt(id);
        }
    }
}
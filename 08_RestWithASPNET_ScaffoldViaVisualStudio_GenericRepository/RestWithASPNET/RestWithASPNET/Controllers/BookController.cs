using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Models;
using RestWithASPNET.Business;
using System;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;

        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookService)
        {
            _logger = logger;
            _bookBusiness = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book cannot be null");
            }

            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book cannot be null");
            }

            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null)
            {
                return BadRequest("Invalid Book");
            }

            _bookBusiness.Delete(id); // Void Method

            return NoContent();
        }
    }
}
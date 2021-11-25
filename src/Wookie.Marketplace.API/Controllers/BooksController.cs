using Microsoft.AspNetCore.Mvc;
using System;
using Wookie.Marketplace.API.Models;
using Wookie.Marketplace.API.Repository;

namespace Wookie.Marketplace.API.Controllers
{
    /// <summary>
    /// APIs for BookStore
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {

        private readonly IBookRepository _bookRepo;

        public BooksController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        /// <summary>
        /// To retreive all books from the collection
        /// </summary>
        /// <returns>Collection of Books with HTTP status code 200</returns>
        [HttpGet]
        public IActionResult Get()
        {         
            return Ok(_bookRepo.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetbyId(long id)
        {
            var book = _bookRepo.GetById(id);
            if (book==null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(409)]
        public IActionResult AddBook(Book book)
        {
            if (_bookRepo.IsExists(book.Title))
            {
                return Conflict();
            }
            else
            {               
                _bookRepo.Add(book);
                return Created(new Uri($"{Request.Path}/{book.Id}", UriKind.Relative), new { id = book.Id });
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBook(long id, Book book)
        {
            var bk = _bookRepo.GetById(id);
            if (bk == null)
            {
                return NotFound($"Couldn't find the book with {id}");
            }
            else
            {
                book.Id = id;
                _bookRepo.Update(book);
                return Ok();
            }
        }
       
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBook(long id)
        {
            var deleteBook = _bookRepo.GetById(id);
            if (deleteBook != null)
            {
                _bookRepo.Delete(deleteBook);
                return NoContent();
            }
            else
            {
                return NotFound($"Couldn't find the book with {id}");
            }
        }
    }
}

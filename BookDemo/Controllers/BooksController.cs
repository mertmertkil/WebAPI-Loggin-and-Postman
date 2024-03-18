using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookDemo.Data;
using BookDemo.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GettAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook(int id)
        {
            var book = ApplicationContext // LINQ
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();
            if (book is null)

                return NotFound();
            return Ok(book);

        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                {
                    return BadRequest();
                }
                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name ="id")]int id,
            [FromBody]Book book)
        {
            // chech book
            var entity = ApplicationContext.
                Books.
                Find(b => b.Id.Equals(id));
            if (entity is null)
            {
                return NotFound();
            }

            //check id

            if (id != book.Id)
            {
                return BadRequest();
            }

            ApplicationContext.Books.Remove(entity);
            book.Id = entity.Id;
            ApplicationContext.Books.Add(book);

            return Ok(book);
        }
        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            ApplicationContext.Books.Clear();
            return NoContent(); //204
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name ="id")] int id)
        {
            var entity = ApplicationContext // varlık gerçekten var mı? check 
                .Books
                .Find(b => b.Id.Equals(id));
            if (entity is null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = $"Id:{id} olan kitap bulunamadı."
                });
            }

            ApplicationContext.Books.Remove(entity);
            return NoContent(); //204
        }
        // patch isteği [FromBody] JsonPatchDocument<T> isteğini zorunlu.
        // Operasyonlar : {
        //                  "op": "add",
        //                  "path": "/name",
        //                  "value": "new value "
        //                          }
        // Add => Belirtilen alana yeni bir değer atar.
        // Copy
        // Invalid
        // Move
        // Remove => Belirtilen alana default bir değer atar.
        // Replace => Belirtilen alanın değerini yeni bir değerle değiştirir.
        // Test
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name ="id")]int id,
            [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));
            if (entity is null)
            {
                return NotFound();
            }
            bookPatch.ApplyTo(entity);
            return NoContent(); //204        
        }
    }
}


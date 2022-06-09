using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patika.WebApi.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Patika.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly PatikaContext _context;

        public BooksController(PatikaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Book> GetListBook()
        {
            var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();

            return bookList;
        }

        [HttpGet("Id")]
        public List<Book> GetById(int id)
        {
            var bookList = _context.Books.Where(x => x.Id == id).ToList<Book>();


            return bookList;
        }
        [HttpPost]

      public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);

           
            if(book != null)
            {

                return BadRequest();
            }
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public IActionResult UpdateBook([FromBody] Book newBook)
        {

            var book = _context.Books.SingleOrDefault(x=>x.Id==newBook.Id);
            if (book == null)
            {

                return BadRequest();
            }
            _context.Books.Update(newBook);
            _context.SaveChanges();


            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
            {
                return BadRequest();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}

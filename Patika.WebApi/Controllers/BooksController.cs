using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patika.WebApi.BookOperations.DeleteBook;
using Patika.WebApi.BookOperations.GetBooks;
using Patika.WebApi.BookOperations.UpdateBook;
using Patika.WebApi.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using static Patika.WebApi.BookOperations.DeleteBook.DeleteBookCommand;
using static Patika.WebApi.BookOperations.GetBooks.CreateBookCommand;
using static Patika.WebApi.BookOperations.UpdateBook.UpdateBookCommand;

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
        public IActionResult GetListBook()
        {
            GetBooksQuery getBooks = new GetBooksQuery(_context);
            var result = getBooks.Handle();
            return Ok(result);
        }

        [HttpGet("Id")]
        public List<Book> GetById(int id)
        {
            var bookList = _context.Books.Where(x => x.Id == id).ToList<Book>();


            return bookList;
        }
        [HttpPost]

      public IActionResult AddBook([FromBody] CreateBookVm newBook)
        {

            CreateBookCommand createBookCommand = new CreateBookCommand(_context);
            createBookCommand.Model = newBook;
            createBookCommand.Handle();
            return Ok();
        }

        [HttpPut]

        public IActionResult UpdateBook([FromBody] UpdateBookVm newBook)
        {
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context);
            updateBookCommand.Model = newBook;
            updateBookCommand.Handle();
            return Ok();


        }

        [HttpDelete]
        public IActionResult Delete(KeyVm keyVm)
        {
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
            deleteBookCommand.Model = keyVm;
            deleteBookCommand.Handle();
            return Ok();
        }
    }
}

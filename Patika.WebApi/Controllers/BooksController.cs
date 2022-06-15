using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patika.WebApi.BookOperations.DeleteBook;
using Patika.WebApi.BookOperations.GetBooks;
using Patika.WebApi.BookOperations.UpdateBook;
using Patika.WebApi.DbOperation;
using Patika.WebApi.FluentValidation;
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
        private readonly IMapper _mapper;
        private readonly PatikaContext _context;

        public BooksController(PatikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetListBook()
        {
            GetBooksQuery getBooks = new GetBooksQuery(_context,_mapper);
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

            CreateBookCommand createBookCommand = new CreateBookCommand(_context, _mapper);
            createBookCommand.Model = newBook;
            CreateBookValidator createBookValidator = new CreateBookValidator();
             createBookValidator.ValidateAndThrow(createBookCommand);
             createBookCommand.Handle();
           
            return Ok();
        }

        [HttpPut("id")]

        public IActionResult UpdateBook([FromBody] UpdateBookVm newBook,int id)
        {
         
                UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context);
                updateBookCommand.Model = newBook;
                updateBookCommand.Id = id;
                UpdateValidator validationRules = new UpdateValidator();
                validationRules.ValidateAndThrow(updateBookCommand);
                updateBookCommand.Handle();
         
          
            return Ok();


        }

        [HttpDelete]
        public IActionResult Delete(KeyVm keyVm)
        {
            
                DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);

                deleteBookCommand.Model = keyVm;
                DeleteValidator deleteValidator = new DeleteValidator();
                deleteValidator.ValidateAndThrow(deleteBookCommand);
                deleteBookCommand.Handle();
            return Ok();
           
        }
    }
}

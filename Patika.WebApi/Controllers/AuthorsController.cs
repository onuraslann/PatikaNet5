using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patika.WebApi.AuthorOperations.CreateAuthor;
using Patika.WebApi.AuthorOperations.DeleteAuthor;
using Patika.WebApi.AuthorOperations.GetAuthor;
using Patika.WebApi.AuthorOperations.UpdateAuthor;
using Patika.WebApi.DbOperation;
using Patika.WebApi.FluentValidation;
using static Patika.WebApi.BookOperations.DeleteBook.DeleteBookCommand;

namespace Patika.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PatikaContext _context;

        public AuthorsController(PatikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            GetAuthorQuery getAuthorQuery = new GetAuthorQuery(_context, _mapper);
            var result = getAuthorQuery.Handle();
            return Ok(result);

        }
        [HttpPost]
        public IActionResult Add([FromBody] AuthorCreateVm authorCreateVm)
        {
            CreateAuthorCommand createAuthorCommand = new CreateAuthorCommand(_context, _mapper);
            createAuthorCommand.Model = authorCreateVm;
            CreateAuthorValidator validationRules = new CreateAuthorValidator();
            validationRules.ValidateAndThrow(createAuthorCommand);
            createAuthorCommand.Handle();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] KeyVm keyVm)
        {
            DeleteAuthorCommand deleteAuthorCommand = new DeleteAuthorCommand(_context);
            deleteAuthorCommand.Model = keyVm;
            DeleteAuthorValidator validationRules = new DeleteAuthorValidator();
            validationRules.ValidateAndThrow(deleteAuthorCommand);
            deleteAuthorCommand.Handle();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromBody] AuthorUpdateVm authorUpdate,int id)
        {

            UpdateAuthorCommand updateAuthorCommand = new UpdateAuthorCommand(_context);
            updateAuthorCommand.AuthorId = id;
             updateAuthorCommand.Model = authorUpdate;
            UpdateAuthorValidator validationRules = new UpdateAuthorValidator();
            validationRules.ValidateAndThrow(updateAuthorCommand);
            updateAuthorCommand.Handle();
            return Ok();
        }
    }
}

using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patika.WebApi.DbOperation;
using Patika.WebApi.FluentValidation;
using Patika.WebApi.GenreOperations.CreateGenre;
using Patika.WebApi.GenreOperations.DeleteGenre;
using Patika.WebApi.GenreOperations.GetGenre;
using Patika.WebApi.GenreOperations.UpdateGenre;
using static Patika.WebApi.BookOperations.DeleteBook.DeleteBookCommand;

namespace Patika.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PatikaContext _context;

        public GenresController(PatikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            GenreGetQuery genreGetQuery = new GenreGetQuery(_context, _mapper);
            var result = genreGetQuery.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Add([FromBody] GenreCreateVm genreVm)
        {
            CreateGenreCommand createGenreCommand = new CreateGenreCommand(_context, _mapper);

            createGenreCommand.Model = genreVm;
            CreateGenreValidator createGenreValidator = new CreateGenreValidator();
            createGenreValidator.ValidateAndThrow(createGenreCommand);
            createGenreCommand.Handle();


            return Ok(createGenreCommand);

        }
        [HttpPut]
        public IActionResult Update([FromBody] UpdateVm updateVm , int id)
        {

            UpdateGenreCommand updateGenreCommand = new UpdateGenreCommand(_context);
            updateGenreCommand.Id = id;
            updateGenreCommand.Model = updateVm;
            UpdateGenreValidator updateValidator = new UpdateGenreValidator();
            updateValidator.ValidateAndThrow(updateGenreCommand);
            updateGenreCommand.Handle();

            return Ok();


        }
        [HttpDelete]
        public IActionResult Delete([FromBody] KeyVm keyVm)
        {
            DeleteGenreCommand deleteGenreCommand = new DeleteGenreCommand(_context);
            deleteGenreCommand.Model= keyVm;
            GenreDeleteValidator deleteValidator = new GenreDeleteValidator();
            deleteValidator.ValidateAndThrow(deleteGenreCommand);

            deleteGenreCommand.Handle();
            return Ok();

        }
    }
}

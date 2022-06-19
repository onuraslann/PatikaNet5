using FluentValidation;
using Patika.WebApi.GenreOperations.DeleteGenre;

namespace Patika.WebApi.FluentValidation
{
    public class GenreDeleteValidator:AbstractValidator<DeleteGenreCommand>
    {
        public GenreDeleteValidator()
        {
            RuleFor(x => x.Model.Id).GreaterThan(0);
        }
    }
}

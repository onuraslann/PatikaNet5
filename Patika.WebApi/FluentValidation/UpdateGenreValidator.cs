using FluentValidation;
using Patika.WebApi.GenreOperations.UpdateGenre;

namespace Patika.WebApi.FluentValidation
{
    public class UpdateGenreValidator:AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(2);
            RuleFor(x => x.Model.Name).NotEmpty();
        }
    }
}

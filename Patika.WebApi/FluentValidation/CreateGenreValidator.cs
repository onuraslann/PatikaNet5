using FluentValidation;
using Patika.WebApi.GenreOperations.CreateGenre;

namespace Patika.WebApi.FluentValidation
{
    public class CreateGenreValidator:AbstractValidator<CreateGenreCommand>
        
    {


        public CreateGenreValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(2);
            RuleFor(x => x.Model.Name).NotEmpty();
           
        }
    }
}

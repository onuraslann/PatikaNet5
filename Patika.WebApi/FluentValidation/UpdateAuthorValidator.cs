using FluentValidation;
using Patika.WebApi.AuthorOperations.UpdateAuthor;

namespace Patika.WebApi.FluentValidation
{
    public class UpdateAuthorValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(2).When(x=>x.Model.Name.Trim()!=string.Empty);
            RuleFor(x => x.Model.Surname).MinimumLength(2).When(x => x.Model.Name.Trim() != string.Empty);

           
        }
    }
}

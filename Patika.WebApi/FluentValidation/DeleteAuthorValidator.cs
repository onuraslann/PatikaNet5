using FluentValidation;
using Patika.WebApi.AuthorOperations.DeleteAuthor;

namespace Patika.WebApi.FluentValidation
{
    public class DeleteAuthorValidator:AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(x => x.Model.Id).NotEmpty();
            RuleFor(x => x.Model.Id).GreaterThan(0);
        }
    }
}

using FluentValidation;
using Patika.WebApi.BookOperations.DeleteBook;

namespace Patika.WebApi.FluentValidation
{
    public class DeleteValidator:AbstractValidator<DeleteBookCommand>
    {
        public DeleteValidator()
        {
            RuleFor(x => x.Model.Id).NotEmpty();
            RuleFor(x => x.Model.Id).GreaterThan(0);
        
        }
    }
}

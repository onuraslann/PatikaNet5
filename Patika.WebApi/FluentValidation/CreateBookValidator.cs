using FluentValidation;
using Patika.WebApi.BookOperations.GetBooks;
using System;

namespace Patika.WebApi.FluentValidation
{
    public class CreateBookValidator:AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.PageCount).GreaterThan(0);
            RuleFor(x => x.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(x => x.Model.Title).NotEmpty().MinimumLength(2);
        }
    }
}

using FluentValidation;
using Patika.WebApi.BookOperations.UpdateBook;
using System;

namespace Patika.WebApi.FluentValidation
{
    public class UpdateValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateValidator()
        {
           
            RuleFor(x => x.Model.PageCount).GreaterThan(0);
         
            RuleFor(x => x.Model.Title).NotEmpty().MinimumLength(2);
        }
    }
}

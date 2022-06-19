using FluentValidation;
using Patika.WebApi.AuthorOperations.CreateAuthor;
using System;

namespace Patika.WebApi.FluentValidation
{
    public class CreateAuthorValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Surname).NotEmpty().MinimumLength(2);

            RuleFor(x => x.Model.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}

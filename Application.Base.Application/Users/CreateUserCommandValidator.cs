using System;
using FluentValidation;

namespace Application.Base.Application.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().MinimumLength(10).MaximumLength(50);
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.DateOfBirth).NotNull().Must(d => d < DateTime.Now);
        }
    }
}

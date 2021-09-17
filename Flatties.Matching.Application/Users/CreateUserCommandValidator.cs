using System;
using FluentValidation;

namespace Flatties.Matching.Application.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirebaseUid).NotNull().MaximumLength(50);
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.DateOfBirth).NotNull().Must(d => d < DateTime.Now);
        }
    }
}

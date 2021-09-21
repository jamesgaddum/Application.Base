using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Base.Domain;
using MediatR;

namespace Application.Base.Application
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public class Handler : IRequestHandler<CreateUserCommand, UserDto>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<UserDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    Id = new UserId(command.Id),
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    DateOfBirth = command.DateOfBirth.Value
                };

                _context.Set<User>().Add(user);
                await _context.SaveChangesAsync(cancellationToken);

                return new UserDto
                {
                    Id = user.Id.Value,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth
                };
            }
        }
    }
}

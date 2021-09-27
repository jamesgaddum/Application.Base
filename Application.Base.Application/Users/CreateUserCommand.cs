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
                var userDto = UserDto.MapFrom(new User(
                    id: command.Id,
                    firstName: command.FirstName,
                    lastName: command.LastName,
                    dateOfBirth: command.DateOfBirth.Value
                ));

                _context.Set<UserDto>().Add(userDto);
                await _context.SaveChangesAsync(cancellationToken);

                return userDto;
            }
        }
    }
}

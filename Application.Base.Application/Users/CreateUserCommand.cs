using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Base.Domain;
using MediatR;

namespace Application.Base.Application
{
    public class CreateUserCommand : IRequest<User>
    {
        public UserId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public class Handler : IRequestHandler<CreateUserCommand, User>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var user = _context.Set<User>().Add(new User
                {
                    Id = command.Id,
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    DateOfBirth = command.DateOfBirth.Value
                });

                await _context.SaveChangesAsync(cancellationToken);

                return user.Entity;
            }
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using Flatties.Matching.Domain;
using MediatR;

namespace Flatties.Matching.Application
{
    public class CreateUserCommand : IRequest<User>
    {
        public string FirebaseUid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public class Handler : IRequestHandler<CreateUserCommand, User>
        {
            private readonly IFlattiesDbContext _context;

            public Handler(IFlattiesDbContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var user = _context.Set<User>().Add(new User
                {
                    FirebaseUid = command.FirebaseUid,
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    DateOfBirth = command.DateOfBirth
                });

                await _context.SaveChangesAsync(cancellationToken);

                return user.Entity;
            }
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using Flatties.Matching.Application.Exceptions;
using Flatties.Matching.Domain;
using MediatR;

namespace Flatties.Matching.Application
{
    public class AddFlatmateCommand : IRequest<Flatmate>
    {
        public Guid UserId { get; set; }
        public Guid FlatId { get; set; }

        public class Handler : IRequestHandler<AddFlatmateCommand, Flatmate>
        {
            private readonly IFlattiesDbContext _context;

            public Handler(IFlattiesDbContext context)
            {
                _context = context;
            }

            public async Task<Flatmate> Handle(AddFlatmateCommand command, CancellationToken cancellationToken)
            {
                var user = await _context.Set<User>().FindAsync(command.UserId);

                if (user == null)
                {
                    throw new DomainException("User does not exist.");
                }

                var flat = await _context.Set<Flat>().FindAsync(command.FlatId);

                if (flat == null)
                {
                    throw new DomainException("Flat does not exist.");
                }

                var flatmate = new Flatmate(command.UserId)
                {
                    FlatId = command.FlatId,
                    UserId = command.UserId
                };

                flat.AddFlatmate(flatmate);
                await _context.SaveChangesAsync(cancellationToken);

                return flatmate;
            }
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using Flatties.Matching.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flatties.Matching.Application
{
    public class GetUserQuery : IRequest<User>
    {
        public string FirebaseUid { get; set; }

        public class Handler : IRequestHandler<GetUserQuery, User>
        {
            private readonly IFlattiesDbContext _context;

            public Handler(IFlattiesDbContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                return await _context.Set<User>()
                    .SingleOrDefaultAsync(u => u.FirebaseUid == request.FirebaseUid);
            }
        }
    }
}

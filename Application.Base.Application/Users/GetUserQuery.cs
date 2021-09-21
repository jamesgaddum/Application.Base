using System.Threading;
using System.Threading.Tasks;
using Application.Base.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Base.Application
{
    public class GetUserQuery : IRequest<User>
    {
        public UserId Id { get; set; }

        public class Handler : IRequestHandler<GetUserQuery, User>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                return await _context.Set<User>()
                    .SingleOrDefaultAsync(u => u.Id == request.Id);
            }
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using Application.Base.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Base.Application
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public GetUserQuery(string Id)
        {
            UserId = new UserId(Id);
        }

        public UserId UserId { get; set; }

        public class Handler : IRequestHandler<GetUserQuery, UserDto>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                return await _context.Set<UserDto>()
                    .SingleOrDefaultAsync(u => u.Id == request.UserId.Value);
            }
        }
    }
}

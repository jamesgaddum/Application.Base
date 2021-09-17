using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flatties.Matching.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Flatties.Matching.Application
{
    public class GetFlatmatesQuery : IRequest<IEnumerable<Flatmate>>
    {
        public Guid FlatId { get; set; }

        public class Handler : IRequestHandler<GetFlatmatesQuery, IEnumerable<Flatmate>>
        {
            private readonly IFlattiesDbContext _context;

            public Handler(IFlattiesDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Flatmate>> Handle(GetFlatmatesQuery request, CancellationToken cancellationToken)
            {
                return await _context.Set<Flatmate>()
                    .Where(fm => fm.FlatId == request.FlatId).ToListAsync();
            }
        }
    }
}

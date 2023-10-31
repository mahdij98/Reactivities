using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using persist;

namespace Application.Meetings
{
    public class List
    {
        public class Query : IRequest<List<Meeting>> { }
        public class Handler : IRequestHandler<Query, List<Meeting>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Meeting>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Meetinges.ToListAsync();
            }
        }
    }
}
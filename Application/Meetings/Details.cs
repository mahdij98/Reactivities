using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using persist;

namespace Application.Meetings
{
    public class Details
    {
        public class Query : IRequest<Meeting>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Meeting>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Meeting> Handle(Query request, CancellationToken ccancellationToken)
            {
                return await _context.Meetinges.FindAsync(request.Id)
            }

        }
    }
}
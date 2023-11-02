using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Domain;
using MediatR;
using persist;

namespace Application.Meetings
{
    public class Create
    {
        public class Command : IRequest
        {
            public Meeting? Meeting { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.Meeting is not null) _context.Add(request.Meeting);

                await _context.SaveChangesAsync();

                return Unit.Value;

            }
        }
    }
}

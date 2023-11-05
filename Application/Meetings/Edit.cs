using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using persist;

namespace Application.Meetings
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Meeting Meeting { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {

            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancelationToken)
            {
                var meeting = await _context.Meetinges.FindAsync(request.Meeting.Id);

                meeting.Title = request.Meeting.Title ?? meeting.Title;

                await _context.SaveChangesAsync();


                return Unit.Value;

            }

        }
    }
}
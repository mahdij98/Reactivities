using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using persist;


namespace API.Controllers
{
    public class MeetingesController : BaseApiController
    {
        private readonly DataContext _context;

        public MeetingesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Meeting>>> GetMeetings()
        {
            return await _context.Meetinges.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meeting>> GetMeeting(Guid id)
        {
            return await _context.Meetinges.FindAsync(id);
        }

    }
}
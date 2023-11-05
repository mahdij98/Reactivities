using Application.Meetings;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using persist;


namespace API.Controllers
{
    public class MeetingesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Meeting>>> GetMeetings()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meeting>> GetMeeting(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreatMeeting(Meeting meeting)
        {
            return Ok(await Mediator.Send(new Create.Command { Meeting = meeting }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditMeeting(Guid id, Meeting meeting)
        {
            meeting.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Meeting = meeting }));
        }


    }
}
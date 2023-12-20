using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Calender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IDataContext _dataContext;
        public EventsController(IDataContext context)
        {
            _dataContext = context;
        }

        // GET: api/<EventsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dataContext.events);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var eve = _dataContext.events.Find(e => e.Id == id);
            if (eve == null)
            {
                return NotFound();
            }
            return Ok(eve);
        }

        // POST api/<EventsController>
        [HttpPost]
        public IActionResult Post([FromBody] Event value)
        {



            if (value == null)
            {
                return NoContent();
            }
            else
            {
                _dataContext.events.Add(new Event { Id = value.Id, Title = value.Title, Start = value.Start, End = value.End });
                return Content("added seccusfully");
            }
        }
        //// PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Event value)
        {
            var eventId = _dataContext.events.Find(eventId => eventId.Id == id);
            eventId.Title = value.Title;
            eventId.Start = value.Start;
            eventId.End = value.End;
            return Ok();

        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eventId = _dataContext.events.Find(eventId => eventId.Id == id);
            if (eventId.Start.Year < 1990)
            {
                return BadRequest();
            }

            else
            {
                _dataContext.events.Remove(eventId);

                return Ok();
            }
        }
    }
}

using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {

        private readonly NoteContext _context;

        public NoteController(NoteContext context)
        {
            _context = context;
        }


        // GET: api/Note
        [HttpGet]
        public IEnumerable<Note> GetNotes()
        {
            if (!_context.Notes.Any())
            {
                Console.WriteLine("No notes found");
            }

            return _context.Notes.ToList();
        }

        // GET: api/Note/5
        [HttpGet("{id}", Name = "GetNote")]
        public IActionResult Get(Guid id)
        {
            return Ok("Hello from NoteController");
        }

        // POST: api/Note
        [HttpPost]
        public IActionResult Post(Note note)
        {
            var cookie = Request.Cookies["UserId"];

            Guid userId;
            if (cookie != null)
            {
                userId = Guid.Parse(cookie);

            }
            else
            {
                userId = Guid.NewGuid();
                _context.Users.Add(new User
                {
                    UserId = userId,
                    Username = "deleteme",
                    Email = "deleteme",
                    Password = "deleteme",
                    IsAdmin = false
                });
                _context.SaveChanges();
            }


            note.UserId = userId;
            note.NoteID = Guid.NewGuid();
            _context.Notes.Add(note);
            _context.SaveChanges();
            return Ok("Hai");
        }

        // UPDATE: api/Note/5
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Note note)
        {
            var Note = _context.Notes.Find(id);
            if (Note == null)
            {
                return NotFound();
            }

            Note.Title = note.Title;
            Note.TitleColor = note.TitleColor;
            Note.NoteText = note.NoteText;
            Note.Tag = note.Tag;

            _context.Notes.Update(Note);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(Guid id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            _context.SaveChanges();

            return Ok();
        }


    }
}
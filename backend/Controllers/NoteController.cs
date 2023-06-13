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
        // POST: api/Note
        [HttpPost]
        public IActionResult Post(Note note)
        {
            var cookie_input = note.UserId.ToString();
            var userId = Guid.Parse(cookie_input);
            note.UserId = userId;
            note.NoteID = Guid.NewGuid();
            _context.Notes.Add(note);
            _context.SaveChanges();

            return Ok();
        }

        // UPDATE: api/Note/5
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Note note)
        {
            note = _context.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            note.Title = note.Title;
            note.TitleColor = note.TitleColor;
            note.NoteText = note.NoteText;
            note.Tag = note.Tag;

            _context.Notes.Update(note);
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
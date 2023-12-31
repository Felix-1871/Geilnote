﻿using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly NoteContext _context;

        public UserController(NoteContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            if (!_context.Users.Any())
            {
                Console.WriteLine("No Users found");
            }
            return _context.Users.ToList();
        }

        // POST: api/Note
        [HttpPost]
        public IActionResult Post(User user)
        {


            user.UserId = Guid.NewGuid();
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user.UserId);
        }

        // UPDATE: api/Note/5
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, User user)
        {
            user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Username = user.Username;
            user.Email = user.Email;
            user.Password = user.Password;
            user.IsAdmin = user.IsAdmin;


            _context.Users.Update(user);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok();
        }

    }
}


using ContactBook.Api.DAL;
using ContactBook.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;            
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            return Ok(await _context.contacts.ToListAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetContact(int id)
        {
            var contact = _context.contacts.Find(id);
            if(contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(Contact contact)
        {
            _context.contacts.Add(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(int id, Contact contact)
        {
            if(id != contact.Id)
            {
                return BadRequest();
            }
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.contacts.FindAsync(id);
            if(contact == null)
            {
                return NotFound("Contact NOT found!");
            }
            _context.contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return Ok(contact);
        }
    }
}

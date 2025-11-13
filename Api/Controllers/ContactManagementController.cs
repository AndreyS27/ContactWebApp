using Api.Model;
using Api.ModelDto;
using Api.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ContactManagementController : BaseController
    {
        private readonly IPaginationStorage storage;

        public ContactManagementController(IPaginationStorage storage)
        {
            this.storage = storage;
        }

        [HttpPost("contacts")]
        public async  Task<IActionResult> Create([FromBody] Contact contact) 
        {
            Contact res = await storage.AddAsync(contact);
            if (res != null)
            {
                return Ok(res);
            }
            return Conflict("Контакт с указанным ID существует");
        }

        //[HttpGet("contacts")]
        //public async Task<ActionResult<List<Contact>>> GetContacts()
        //{
        //    var contacts = await storage.GetContactsAsync();
        //    return Ok(contacts);
        //}

        [HttpDelete("contacts/{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            bool res = await storage.RemoveAsync(id);
            if (res)
            {
                return NoContent();
            }
            return BadRequest("Ошибка id");
        }

        [HttpPut("contacts/{id}")]
        public async Task<IActionResult> UpdateContact([FromBody] ContactDto contactDto, int id)
        {
            bool res = await storage.UpdateContactAsync(contactDto, id);
            if (res) return Ok();
            return Conflict("Контакт с указанным ID не найден");
        }

        [HttpGet("contacts/{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await storage.GetContactByIdAsync(id);
            if (contact != null)
            {
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpGet("contacts/page")]
        public async Task<IActionResult> GetContacts(int pageNumber = 1, int pageSize = 5)
        {
            var (contacts, total) = await storage.GetContactsAsync(pageNumber, pageSize);

            var response = new
            {
                Contacts = contacts,
                TotalCount = total,
                CurrentPage = pageNumber,
                PageSize = pageSize
            };
            return Ok(response);
        }
    }
}

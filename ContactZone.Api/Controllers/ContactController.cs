using ContactZone.Api.Dtos;
using ContactZone.Api.DTOs;
using ContactZone.Application.Services;
using ContactZone.Domain.Domains;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactZone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IContactPersonalDataService _contactPersonalDataService;

        public ContactController(IContactService contactService, IContactPersonalDataService contactPersonalDataService)
        {
            _contactService = contactService;
            _contactPersonalDataService = contactPersonalDataService;   
        }

        // POST: api/Contact
        [HttpPost]
        public async Task<IActionResult> Create(PostContactAndPersonalDataDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid contact data.");

            var contactDomain = PostContactDto.ToDomain(new PostContactDto() { Name = dto.Name});
            await _contactService.AddAsync(contactDomain);
            var contactPersonalDataDomain = ContactPersonalDataDto.ToDomain(new ContactPersonalDataDto()
            {
                DDD = dto.DDD,
                Email = dto.Email,
                Phone = dto.Phone
            }, 
            contactDomain.Id);
            await _contactPersonalDataService.AddAsync(contactPersonalDataDomain);

            return CreatedAtAction(nameof(GetById), new { id = contactDomain.Id }, contactDomain);
        }

        // GET: api/Contact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDomain>>> GetAll()
        {
            var contacts = await _contactService.GetAllAsync();
            return Ok(contacts);
        }

        // GET: api/Contact/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDomain>> GetById(int id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        // PUT: api/Contact/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PostContactDto contactDto)
        {
            if (contactDto == null || id <= 0)
                return BadRequest("Invalid contact data.");

            var contact = await _contactService.GetByIdAsync(id);
            if (contact == null)
                return NotFound();

            contact.Name = contactDto.Name;
            _contactService.Update(contact);

            return NoContent();
        }

        // DELETE: api/Contact/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            if (contact == null)
                return NotFound();

            await _contactService.RemoveAsync(contact);
            return NoContent();
        }
    }
}

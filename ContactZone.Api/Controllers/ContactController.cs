using ContactZone.Api.Dtos;
using ContactZone.Application.Services;
using ContactZone.Domain.Domains;
using Microsoft.AspNetCore.Mvc;

namespace ContactZone.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // POST: api/Contact
        [HttpPost]
        public async Task<IActionResult> Create(PostContactDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid contact data.");

            var contactDomain = PostContactDto.ToDomain(new PostContactDto() 
            { 
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                DDD = dto.DDD,
            });
            await _contactService.AddAsync(contactDomain);

            return CreatedAtAction(nameof(GetById), new { id = contactDomain.Id }, contactDomain);
        }

        // GET: api/Contact
        /// <summary>
        /// Caso o usuário informe ddd 0 a busca retorna todos os contatos
        /// </summary>
        /// <param name="ddd"></param>
        /// <returns></returns>
        [HttpGet("FilterByDDD/{ddd}")]
        public async Task<IActionResult> GetAll(int ddd)
        {
            if (ddd < 0)
            {
                return BadRequest("DDD cannot be negative.");
            }

            IEnumerable<ContactDomain> contacts;

            if (ddd == 0)
            {
                contacts = await _contactService.GetContactWithAllInformation();
            }
            else
            {
                contacts = await _contactService.GetContactFilteringByDDD(ddd);
            }

            var contactDtos = ContactDto.MapToDto(contacts);

            return Ok(contactDtos);
        }

        // GET: api/Contact/{id}
        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("The id must be a positive value");

            var contact = await _contactService.GetByIdAsync(id);

            if (contact == null)
                return NotFound();

            var contactDto = ContactDto.MapToDto(contact);

            return Ok(contactDto);
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

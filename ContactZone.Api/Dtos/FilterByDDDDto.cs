using ContactZone.Domain.Domains;

namespace ContactZone.Api.Dtos
{
    public class FilterByDDDDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DDD { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public static List<FilterByDDDDto> MapToDto(IEnumerable<ContactDomain> contacts)
        {
            return contacts.Select(contact => new FilterByDDDDto
            {
                Id = contact.Id,
                Name = contact.Name,
                DDD = contact.DDD,
                Phone = contact.Phone,
                Email = contact.Email
            }).ToList();
        }
    }
}

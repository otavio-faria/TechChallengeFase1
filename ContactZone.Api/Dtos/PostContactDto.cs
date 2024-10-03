using ContactZone.Domain.Domains;

namespace ContactZone.Api.DTOs
{
    public class PostContactDto
    {
        public string Name { get; set; }

        public static ContactDomain ToDomain(PostContactDto contactDto)
        {
            return new ContactDomain
            {
                Name = contactDto.Name,
            };
        }
    }
}

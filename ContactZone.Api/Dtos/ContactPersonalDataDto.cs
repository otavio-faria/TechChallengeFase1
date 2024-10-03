using ContactZone.Domain.Domains;

namespace ContactZone.Api.DTOs
{
    public class ContactPersonalDataDto
    {
        public string DDD { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public static ContactPersonalDataDomain ToDomain(ContactPersonalDataDto contactPersonalDataDto, int contactId)
        {
            return new ContactPersonalDataDomain
            {
                DDD = contactPersonalDataDto.DDD,
                Phone = contactPersonalDataDto.Phone,
                Email = contactPersonalDataDto.Email,
                ContactId = contactId
            };
        }
    }
}

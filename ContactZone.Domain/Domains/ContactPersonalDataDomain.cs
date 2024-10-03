namespace ContactZone.Domain.Domains
{
    public class ContactPersonalDataDomain
    {
        public int Id { get; set; }
        public string DDD { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Foreign Key
        public int ContactId { get; set; }  // Chave estrangeira

        // Navigation Property
        public ContactDomain Contact { get; set; }
    }
}

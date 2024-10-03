namespace ContactZone.Domain.Domains
{
    public class ContactDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ContactPersonalDataDomain ContactPersonalDataDomain { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactZone.Domain.Domains
{
    public class ContactPersonalDataDomain
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string DDD { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

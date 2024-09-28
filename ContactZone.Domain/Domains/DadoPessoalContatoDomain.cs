using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactZone.Domain.Domains
{
    public class DadoPessoalContatoDomain
    {
        public int Id { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}

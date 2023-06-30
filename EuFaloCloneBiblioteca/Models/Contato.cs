using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuFaloCloneBiblioteca.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public string? Sexo { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? CPF { get; set; }
        public DateTime DataCadastro { get; set; }
        public string? Email { get; set; }

        public List<VendaContato>? VendaContatos { get; set; }
    }
}

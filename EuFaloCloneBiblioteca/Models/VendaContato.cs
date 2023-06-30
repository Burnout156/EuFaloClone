using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuFaloCloneBiblioteca.Models
{
    public class VendaContato
    {
        public int VendaContatoId { get; set; }
        public int ContatoId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal Valor { get; set; }

        public Contato? Contato { get; set; }
        public List<VendaDetalheContato> VendaDetalheContatos { get; set; }
    }
}

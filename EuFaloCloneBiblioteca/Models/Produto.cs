using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuFaloCloneBiblioteca.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }     
        public string NomeProduto { get; set; }
        public List<VendaDetalheContato> VendaDetalheContatos { get; set; }
    }
}

using EuFaloCloneBiblioteca.Contexts;
using EuFaloCloneBiblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EuFaloClone.Controllers
{
    public class ContatoController : Controller
    {
        private readonly GerenciadorDbContext db;

        public ContatoController(GerenciadorDbContext dbContext)
        {
            db = dbContext;
        }

        public ActionResult Pesquisar(string term)
        {
            var contatos = db.Contato.Where(c => c.Nome.Contains(term) || c.CPF.Contains(term)).ToList();
            return View(contatos);
        }

        public ActionResult Compras(int contatoId)
        {
            var vendaContato = db.VendaContato
                                 .Include(vc => vc.VendaDetalheContatos)
                                    .ThenInclude(vdc => vdc.Produto)
                                 .FirstOrDefault(vc => vc.VendaContatoId == contatoId);

            if (vendaContato == null)
            {
                return NotFound();
            }

            return View(vendaContato);
        }
    }
}

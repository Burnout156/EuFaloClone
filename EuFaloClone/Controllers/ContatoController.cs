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
            try
            {
                var contatos = string.IsNullOrEmpty(term)
                    ? null
                    : db.Contato.AsEnumerable().Where(c =>
                        c.Nome != null &&
                        ((!string.IsNullOrEmpty(c.Nome) && ELetra(term) && c.Nome.StartsWith(term, StringComparison.OrdinalIgnoreCase)) || c.CPF.Contains(term))
                    ).ToList();

                return View(contatos);
            }
            catch (Exception ex)
            {
                // Lidar com o erro de valor nulo aqui
                // Por exemplo, redirecionar para uma página de erro ou retornar uma mensagem de erro adequada
                return View(new List<Contato>());
            }
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

        //Verifica se o que digitou é letra
        private bool ELetra(string term)
        {
            return term.All(char.IsLetter);
        }
    }
}

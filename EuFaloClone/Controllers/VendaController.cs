using EuFaloCloneBiblioteca.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EuFaloClone.Controllers
{
    public class VendaController : Controller
    {
        private readonly GerenciadorDbContext db;

        public VendaController(GerenciadorDbContext dbContext)
        {
            db = dbContext;
        }

        public ActionResult Detalhes(int vendaContatoId)
        {
            var itensVenda = db.VendaDetalheContato
                .Where(v => v.VendaContatoId == vendaContatoId)
                .Include(v => v.Produto)
                .ToList();
            return View(itensVenda);
        }
    }
}

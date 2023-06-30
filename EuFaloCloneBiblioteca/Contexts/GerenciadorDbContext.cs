using EuFaloCloneBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EuFaloCloneBiblioteca.Contexts
{
    public class GerenciadorDbContext : DbContext
    {
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<VendaContato> VendaContato { get; set; }
        public DbSet<VendaDetalheContato> VendaDetalheContato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source=bespin.agentemr.com.br,2432;Initial Catalog=db_RecrutamentoASP;User ID=RecrutamentoASP;Password=7zj@U&lAffNo;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VendaContato>()
                .HasOne(vc => vc.Contato)
                .WithMany(c => c.VendaContatos)
                .HasForeignKey(vc => vc.ContatoId);

            modelBuilder.Entity<VendaContato>()
                .HasMany(vc => vc.VendaDetalheContatos)
                .WithOne(vdc => vdc.VendaContato)
                .HasForeignKey(vdc => vdc.VendaContatoId);

            modelBuilder.Entity<VendaDetalheContato>()
                .HasOne(vdc => vdc.Produto)
                .WithMany(p => p.VendaDetalheContatos)
                .HasForeignKey(vdc => vdc.ProdutoId);
        }
    }   
}


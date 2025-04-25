using Microsoft.EntityFrameworkCore;
using LanceCerto.WebApp.Models;

namespace LanceCerto.WebApp.Data
{
    public class LanceCertoDbContext : DbContext
    {
        public LanceCertoDbContext(DbContextOptions<LanceCertoDbContext> options) : base(options) { }

        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Leilao> Leiloes { get; set; }
        public DbSet<Lance> Lances { get; set; }
        public DbSet<ImovelFavorito> ImoveisFavoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Imovel>().ToTable("Imoveis");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Mensagem>().ToTable("Mensagens");
            modelBuilder.Entity<Leilao>().ToTable("Leiloes");
            modelBuilder.Entity<Lance>().ToTable("Lances");
            modelBuilder.Entity<ImovelFavorito>().ToTable("ImoveisFavoritos");

            // Definir chave composta para ImovelFavorito
            modelBuilder.Entity<ImovelFavorito>()
                .HasKey(fav => new { fav.UsuarioId, fav.ImovelId });

            modelBuilder.Entity<Imovel>()
                .Property(p => p.PrecoMinimo)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Leilao>()
                .Property(p => p.MaiorLanceAtual)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Lance>()
                .Property(p => p.ValorLance)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
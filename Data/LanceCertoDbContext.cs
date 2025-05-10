using LanceCerto.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LanceCerto.WebApp.Data
{
    public class LanceCertoDbContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
    {
        public LanceCertoDbContext(DbContextOptions<LanceCertoDbContext> options)
            : base(options)
        {
        }

        // DbSets para entidades principais do projeto
        public DbSet<Imovel> Imoveis { get; set; } = null!;
        public DbSet<Leilao> Leiloes { get; set; } = null!;
        public DbSet<Lance> Lances { get; set; } = null!;
        public DbSet<Mensagem> Mensagens { get; set; } = null!;
        public DbSet<ImovelFavorito> ImoveisFavoritos { get; set; } = null!;
        // IdentityDbContext já gerencia o DbSet<Usuario>, mas você pode declarar explicitamente se quiser
        public DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // ESSENCIAL para configurar Identity corretamente

            // Renomear tabelas padrão do Identity para manter a nomenclatura coesa
            builder.Entity<Usuario>().ToTable("Usuarios");
            builder.Entity<IdentityRole<int>>().ToTable("Roles");
            builder.Entity<IdentityUserRole<int>>().ToTable("UsuarioRoles");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UsuarioClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UsuarioLogins");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<int>>().ToTable("UsuarioTokens");

            // Configuração para ImovelFavorito (chave composta)
            builder.Entity<ImovelFavorito>(entity =>
            {
                entity.HasKey(e => new { e.UsuarioId, e.ImovelId });

                entity.HasOne(e => e.Imovel)
                      .WithMany(i => i.ImoveisFavoritos)
                      .HasForeignKey(e => e.ImovelId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Usuario)
                      .WithMany()
                      .HasForeignKey(e => e.UsuarioId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Ajustar precisão decimal para valor de lance
            builder.Entity<Lance>(entity =>
            {
                entity.Property(e => e.ValorLance).HasColumnType("decimal(18,2)");
            });

            builder.Entity<Leilao>(entity =>
            {
                entity.Property(e => e.MaiorLanceAtual).HasColumnType("decimal(18,2)");
            });

            builder.Entity<Imovel>(entity =>
            {
                entity.Property(e => e.PrecoMinimo).HasColumnType("decimal(18,2)");
            });

            // Correção de múltiplos caminhos de deleção em Mensagem (evita erro de múltiplos cascades)
            builder.Entity<Mensagem>(entity =>
            {
                entity.HasOne(m => m.Remetente)
                      .WithMany()
                      .HasForeignKey(m => m.RemetenteId)
                      .OnDelete(DeleteBehavior.Restrict); // evita conflito com Destinatario

                entity.HasOne(m => m.Destinatario)
                      .WithMany()
                      .HasForeignKey(m => m.DestinatarioId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.ImovelRelacionado)
                      .WithMany()
                      .HasForeignKey(m => m.ImovelRelacionadoId)
                      .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
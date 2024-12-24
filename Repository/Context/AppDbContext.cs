using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        // DbSet para representar as tabelas
        public required DbSet<Produto> Produtos { get; set; }
        public required DbSet<Categoria> Categorias { get; set; }

        // Configurações adicionais (opcional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Categoria
            modelBuilder.Entity<Categoria>()
                .ToTable("Categorias")
                .HasKey(c => c.Id); // Define 'Id' como chave primária

            // Configurações de Produto
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(p => p.Preco)
                      .HasPrecision(18, 2); // Definir precisão e escala (exemplo: decimal(18,2))
            });

            // Configuração da entidade Produto
            modelBuilder.Entity<Produto>()
                .ToTable("Produtos")
                .HasKey(p => p.Id); // Define 'Id' como chave primária

            // Relacionamento entre Produto e Categoria
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Categoria) // Produto tem 1 Categoria
                .WithMany(c => c.Produtos) // Categoria tem muitos Produtos
                .HasForeignKey(p => p.CategoriaId) // Produto usa CategoriaId como chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); // Evita exclusão em cascata

            // Configurar as colunas de auditoria
            modelBuilder.Entity<Categoria>()
                .Property(c => c.DataCriacao)
                .HasDefaultValueSql("GETDATE()");  // Ou use DateTime.UtcNow em C#

            modelBuilder.Entity<Categoria>()
                .Property(c => c.DataAtualizacao)
                .IsRequired(false);

            modelBuilder.Entity<Categoria>()
                .Property(c => c.DataExclusao)
                .IsRequired(false);

            modelBuilder.Entity<Produto>()
                .Property(p => p.DataCriacao)
                .HasDefaultValueSql("GETDATE()");  // Ou use DateTime.UtcNow em C#

            modelBuilder.Entity<Produto>()
                .Property(p => p.DataAtualizacao)
                .IsRequired(false);

            modelBuilder.Entity<Produto>()
                .Property(p => p.DataExclusao)
                .IsRequired(false);
        }
    }
}

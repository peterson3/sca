using Microsoft.EntityFrameworkCore;

namespace SCA.Ativos.API.Model
{
    public class AtivoContext : DbContext
    {

        public AtivoContext(DbContextOptions<AtivoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ativo>()
                .HasOne<TipoAtivo>(t => t.Tipo)
                .WithMany()
                .HasForeignKey(t => t.TipoId);

       
        }

        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<TipoAtivo> TipoAtivos { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }
    }
}

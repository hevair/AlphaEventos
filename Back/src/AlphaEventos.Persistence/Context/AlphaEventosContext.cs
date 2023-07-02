using AlphaEventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace AlphaEventos.Persistence.Context
{
    public class AlphaEventosContext: DbContext
    {

        public AlphaEventosContext(DbContextOptions<AlphaEventosContext> options): base(options)
        {
            
        }

        public DbSet<Evento> Eventos {get; set;}
        public DbSet<Lote> Lotes {get; set;}
        public DbSet<Palestrante> Palestrantes {get; set;}
        public DbSet<PalestranteEvento> PalestrantesEventos {get; set;}
        public DbSet<RedeSocial> RedeSocials {get; set;}
        public DbSet<PalestranteEvento> Lote {get; set;}


         protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(pe => new {pe.EventoId, pe.PalestranteId});

            modelBuilder.Entity<Evento>()
            .HasMany(e => e.RedeSociais)
            .WithOne(rs => rs.Evento)
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Palestrante>()
            .HasMany(p => p.RedeSociais)
            .WithOne(rs => rs.Palestrante)
            .OnDelete(DeleteBehavior.ClientCascade);

        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using AlphaEventos.Domain;
using AlphaEventos.Persistence.Context;
using AlphaEventos.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaEventos.Persistence
{
    public class EventosRepository : IEventosRepository
    {
        private readonly AlphaEventosContext _context;

        public EventosRepository(AlphaEventosContext context)
        {
            _context = context;

        }

        public async Task<Evento> getEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos.AsNoTracking()
                    .Include(e => e.Lote)
                    .Include(e => e.RedeSociais);

            if(includePalestrante){
                query = query.Include(e => e.PalestrateEvento)
                              .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos.AsNoTracking()
                    .Include(e => e.Lote)
                    .Include(e => e.RedeSociais);

            if(includePalestrante){
                query = query.Include(e => e.PalestrateEvento)
                              .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();

        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos.AsNoTracking()
                    .Include(e => e.Lote)
                    .Include(e => e.RedeSociais);

            if(includePalestrante){
                query = query.Include(e => e.PalestrateEvento)
                              .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

    }
}
using System.Linq;
using System.Threading.Tasks;
using AlphaEventos.Domain;
using AlphaEventos.Persistence.Context;
using AlphaEventos.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaEventos.Persistence
{
    public class PalestranteRepository : IPalestranteRepository
    {
        private readonly AlphaEventosContext _context;

        public PalestranteRepository(AlphaEventosContext context)
        {
            _context = context;

        }
       
        public async Task<Palestrante[]> GetAllPalestrantesAsync( bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                    .Include(e => e.RedeSociais);

            if(includeEventos){
                query = query.Include(e => e.PalestrateEvento)
                             .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
                    .Include(p => p.RedeSociais);

            if(includeEventos){
                query = query.Include(pe => pe.PalestrateEvento)
                             .ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower() == nome.ToLower());

            return await query.ToArrayAsync();
        }


        public async Task<Palestrante> getPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
                    .Include(p => p.RedeSociais);

            if(includeEventos){
                query = query.Include(pe => pe.PalestrateEvento)
                             .ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }


    }
}
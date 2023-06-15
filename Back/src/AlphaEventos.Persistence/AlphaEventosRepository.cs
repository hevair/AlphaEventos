using System.Linq;
using System.Threading.Tasks;
using AlphaEventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace AlphaEventos.Persistence
{
    public class AlphaEventosRepository : IAlphaEventosRepository
    {
        private readonly AlphaEventosContext _context;

        public AlphaEventosRepository(AlphaEventosContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangeAsync()
        {
           return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Evento> getEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _context.Eventos
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
            IQueryable<Evento> query = _context.Eventos
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
            IQueryable<Evento> query = _context.Eventos
                    .Include(e => e.Lote)
                    .Include(e => e.RedeSociais);

            if(includePalestrante){
                query = query.Include(e => e.PalestrateEvento)
                              .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public Task<Palestrante[]> GetAllPalestrantesAsync( bool includeEventos)
        {
            throw new System.NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }


        public Task<Palestrante> getPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {
            throw new System.NotImplementedException();
        }


    }
}
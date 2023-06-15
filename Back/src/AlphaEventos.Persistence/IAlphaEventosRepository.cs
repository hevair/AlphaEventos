using System.Threading.Tasks;
using AlphaEventos.Domain;

namespace AlphaEventos.Persistence
{
    public interface IAlphaEventosRepository
    {
         void Add<T>(T entity) where T: class;
         void update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleteRange<T>(T[] entity) where T: class;

         Task<bool> SaveChangeAsync();

         //Eventos

         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrante);
         Task<Evento> getEventoByIdAsync(int eventoId, bool includePalestrante);

         // Palestrante

          Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
         Task<Palestrante> getPalestranteByIdAsync(int PalestranteId, bool includeEventos);
    }
}
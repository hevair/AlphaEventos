using System.Threading.Tasks;
using AlphaEventos.Domain;

namespace AlphaEventos.Persistence.Interfaces
{
    public interface IEventosRepository
    {

         //Eventos

         Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false);
         Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false);
         Task<Evento> getEventoByIdAsync(int eventoId, bool includePalestrante = false);
    }
}
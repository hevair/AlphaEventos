using System.Threading.Tasks;
using AlphaEventos.Domain;

namespace AlphaEventos.Persistence.Interfaces

{
    public interface IPalestranteRepository
    {
        // Palestrante

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> getPalestranteByIdAsync(int PalestranteId, bool includeEventos);
    }
}
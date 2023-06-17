using System.Threading.Tasks;
using AlphaEventos.Domain;

namespace AlphaEventos.Persistence.Interfaces
{
    public interface IRepository
    {
         void Add<T>(T entity) where T: class;
         void update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleteRange<T>(T[] entity) where T: class;
         Task<bool> SaveChangeAsync();

    }
}
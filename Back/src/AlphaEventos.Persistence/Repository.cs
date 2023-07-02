using System.Threading.Tasks;
using AlphaEventos.Persistence.Context;
using AlphaEventos.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlphaEventos.Persistence
{
    public class Repository : IRepository
    {
        private readonly AlphaEventosContext _context;

        public Repository(AlphaEventosContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

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
    }
}
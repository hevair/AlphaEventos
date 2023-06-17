using System;
using System.Threading.Tasks;
using AlphaEventos.Application.Interfaces;
using AlphaEventos.Domain;
using AlphaEventos.Persistence;
using AlphaEventos.Persistence.Interfaces;

namespace AlphaEventos.Application
{
    public class EventosService : IEventoService
    {
        private readonly EventosRepository _eventosRepository;
        private readonly IRepository _repository;
        public EventosService(EventosRepository eventosRepository, IRepository repository)
        {
            _repository = repository;
            _eventosRepository = eventosRepository;

        }
        public async Task<Evento> AddEventos(Evento evento)
        {
            try
            {
                _repository.Add(evento);
                if (await _repository.SaveChangeAsync())
                    return await _eventosRepository.getEventoByIdAsync(evento.Id, false);

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento evento)
        {
            try
            {
                var eventoResult = await _eventosRepository.getEventoByIdAsync(evento.Id, false);
                if (eventoResult == null) return null;

                _repository.update(eventoResult);

                if (await _repository.SaveChangeAsync())
                {
                    return await _eventosRepository.getEventoByIdAsync(evento.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
               try
            {
                var eventoResult = await _eventosRepository.getEventoByIdAsync(eventoId);
                if (eventoResult == null) throw new Exception("Evento não encontrado");

                _repository.Delete(eventoResult);

                return await _repository.SaveChangeAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            try
            {
                var eventoResult = await _eventosRepository.GetAllEventosAsync();
                if (eventoResult == null) return null;
                
                return eventoResult;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            try
            {
                var eventoResult = await _eventosRepository.GetAllEventosByTemaAsync(tema, includePalestrante);
                if (eventoResult == null) return null;
                
                return eventoResult;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> getEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
             try
            {
                var eventoResult = await _eventosRepository.getEventoByIdAsync(eventoId, includePalestrante);
                if (eventoResult == null) return null;
                
                return eventoResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
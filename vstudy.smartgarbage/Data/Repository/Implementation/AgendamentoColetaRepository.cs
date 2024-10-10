using Microsoft.EntityFrameworkCore;
using vstudy.smartgarbage.Data.Context;
using vstudy.smartgarbage.Data.Repository.Interface;
using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Data.Repository.Implementation
{
    public class AgendamentoColetaRepository : IAgendamentoColetaRepository
    {
        private readonly DatabaseContext _context;
        public AgendamentoColetaRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(AgendamentoColetaModel agendamento)
        {
            _context.AgendamentoColeta.Add(agendamento);
            _context.SaveChanges();
        }

        public void Delete(AgendamentoColetaModel agendamento)
        {
            _context.AgendamentoColeta.Remove(agendamento);
            _context.SaveChanges();
        }

        public IEnumerable<AgendamentoColetaModel> GetAll()
        {
            return _context.AgendamentoColeta
                .Include(c => c.Usuario)
                .Include(c => c.PontoColeta)
                //.Include(d => d.ResiduoColeta)
                //.ThenInclude(e => e.PontoColeta)
                .ToList();
        }

        public AgendamentoColetaModel GetById(int id)
        {
            return _context.AgendamentoColeta
                .Include(c => c.Usuario)
                .Include(c => c.PontoColeta)
                .FirstOrDefault(c => c.AgendamentoId == id);
        }


        public void Update(AgendamentoColetaModel agendamento)
        {
            _context.Update(agendamento);
            _context.SaveChanges();
        }
    }
}

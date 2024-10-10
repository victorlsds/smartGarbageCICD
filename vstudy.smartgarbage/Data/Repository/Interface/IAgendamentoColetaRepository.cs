using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Data.Repository.Interface
{
    public interface IAgendamentoColetaRepository
    {
        IEnumerable<AgendamentoColetaModel> GetAll();
        AgendamentoColetaModel GetById(int id);
        void Add(AgendamentoColetaModel agendamento);
        void Update(AgendamentoColetaModel agendamento);
        void Delete(AgendamentoColetaModel agendamento);
    }
}

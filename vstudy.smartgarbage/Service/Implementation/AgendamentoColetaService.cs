using vstudy.smartgarbage.Data.Repository.Interface;
using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.Service.Interface;

namespace vstudy.smartgarbage.Service.Implementation
{
    public class AgendamentoColetaService : IAgendamentoColetaService
    {
        private readonly IAgendamentoColetaRepository _repository;
        public AgendamentoColetaService(IAgendamentoColetaRepository repository)
        {
            _repository = repository;
        }
        public void AtualizarAgendamento(AgendamentoColetaModel agendamentoColeta)
        {
            _repository.Update(agendamentoColeta);
        }

        public void CriarAgendamento(AgendamentoColetaModel agendamentoColeta)
        {
            _repository.Add(agendamentoColeta);
        }

        public void DeletarAgendamento(int id)
        {
            var agendamento = _repository.GetById(id);
            if (agendamento != null)
            {
                _repository.Delete(agendamento);
            }
        }

        public IEnumerable<AgendamentoColetaModel> ListarAgendamentos()
        {
            return _repository.GetAll();
        }

        public AgendamentoColetaModel ObterAgendamentosPorId(int id)
        {
            return _repository.GetById(id);
        }
    }
}

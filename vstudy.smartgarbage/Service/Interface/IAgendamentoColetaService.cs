using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Service.Interface
{
    public interface IAgendamentoColetaService
    {
        IEnumerable<AgendamentoColetaModel> ListarAgendamentos();
        AgendamentoColetaModel ObterAgendamentosPorId(int id);
        void CriarAgendamento(AgendamentoColetaModel agendamentoColeta);
        void AtualizarAgendamento(AgendamentoColetaModel agendamentoColeta);
        void DeletarAgendamento(int id);
    }
}

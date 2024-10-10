namespace vstudy.smartgarbage.ViewModel
{
    public class AgendamentoCadastroVM
    {
        public int AgendamentoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataAgendamento { get; set; }
        public int PontoColetaId { get; set; }
        public string Status { get; set; }
    }
}

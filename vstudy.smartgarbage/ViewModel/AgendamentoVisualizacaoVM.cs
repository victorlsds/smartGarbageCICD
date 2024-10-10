namespace vstudy.smartgarbage.ViewModel
{
    public class AgendamentoVisualizacaoVM
    {
        public int AgendamentoId { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public DateTime DataAgendamento { get; set; }
        public int PontoColetaId { get; set; }
        public string PontoColetaEndereco { get; set; }
        public string Status { get; set; }
    }

}

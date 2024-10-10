namespace vstudy.smartgarbage.Model
{
    public class AgendamentoColetaModel
    {
        public int AgendamentoId { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
        public DateTime DataAgendamento { get; set; }
        public int PontoColetaId { get; set; }
        public PontosColetaModel PontoColeta { get; set; }
        public string Status { get; set; }
    }
}
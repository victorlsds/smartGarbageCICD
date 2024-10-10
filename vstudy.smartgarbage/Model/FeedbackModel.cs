namespace vstudy.smartgarbage.Model
{
    public class FeedbackModel
    {
        public int FeedBackId { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
        public int AgendamentoColetaId { get; set; }
        public AgendamentoColetaModel? AgendamentoColetaLixo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataFeedback { get; set; }
    }
}

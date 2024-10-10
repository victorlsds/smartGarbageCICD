using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.ViewModel
{
    public class FeedbackCadastroVM
    {
        public int FeedBackId { get; set; }
        public int UsuarioId { get; set; }
        public int AgendamentoColetaId { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataFeedback { get; set; }
    }
}

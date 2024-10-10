namespace vstudy.smartgarbage.Model
{
    public class ResiduoColetaModel
    {
        public int ResiduoColetaId { get; set; }
        public String TipoResiduo { get; set; }
        public int AgendamentoColetaId { get; set; }
        public AgendamentoColetaModel AgendamentoColeta { get; set; }
        //      public int PontoColetaId { get; set; }
        //      public PontosColetaModel PontoColeta { get; set; }
        //      public AgendamentoColetaModel AgendamentoColeta { get; protected set; }
    }
}
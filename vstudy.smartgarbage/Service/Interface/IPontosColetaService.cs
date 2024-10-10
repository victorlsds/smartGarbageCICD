using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Service.Interface
{
    public interface IPontosColetaService
    {
        IEnumerable<PontosColetaModel> ListarPontosColeta();
        PontosColetaModel ObterPontoColetaPorId(int id);
        void CriarPontoColeta(PontosColetaModel pontoColeta);
        void AtualizarPontoColeta(PontosColetaModel pontoColeta);
        void DeletarPontoColeta(int id);
    }
}

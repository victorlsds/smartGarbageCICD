using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Service.Interface
{
    public interface IResiduoColetaService
    {
        IEnumerable<ResiduoColetaModel> ListarResiduos();
        ResiduoColetaModel ObterResiduosPorId(int id);
        void CriarResiduos(ResiduoColetaModel residuoColeta);
        void AtualizarResiduos(ResiduoColetaModel residuoColeta);
        void DeletarResiduos(int id);
    }
}

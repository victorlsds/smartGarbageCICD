using vstudy.smartgarbage.Data.Repository.Interface;
using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.Service.Interface;

namespace vstudy.smartgarbage.Service.Implementation
{
    public class PontosColetaService : IPontosColetaService
    {
        private readonly IPontosColetaRepository _repository;
        public PontosColetaService(IPontosColetaRepository repository)
        {
            _repository = repository;
        }
        public void AtualizarPontoColeta(PontosColetaModel pontoColeta)
        {
            _repository.Update(pontoColeta);
        }

        public void CriarPontoColeta(PontosColetaModel pontoColeta)
        {
            _repository.Add(pontoColeta);
        }

        public void DeletarPontoColeta(int id)
        {
            var pontoColeta = _repository.GetById(id);
            if (pontoColeta == null)
            {
                _repository.Delete(pontoColeta);
            }
        }

        public IEnumerable<PontosColetaModel> ListarPontosColeta()
        {
            return _repository.GetAll();
        }

        public PontosColetaModel ObterPontoColetaPorId(int id)
        {
            return _repository.GetById(id);
        }
    }
}

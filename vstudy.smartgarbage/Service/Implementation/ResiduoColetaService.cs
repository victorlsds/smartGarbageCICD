using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.Service.Interface;
using vstudy.smartgarbage.Data.Repository.Interface;

namespace vstudy.smartgarbage.Service.Implementation
{
    public class ResiduoColetaService : IResiduoColetaService
    {
        private readonly IResiduoColetaRepository _repository;
        public ResiduoColetaService(IResiduoColetaRepository repository)
        {
            _repository = repository;
        }
        public void AtualizarResiduos(ResiduoColetaModel agendamentoColeta)
        {
            _repository.Update(agendamentoColeta);
        }

        public void CriarResiduos(ResiduoColetaModel agendamentoColeta)
        {
            _repository.Add(agendamentoColeta);
        }

        public void DeletarResiduos(int id)
        {
            var residuo = _repository.GetById(id);
            if (residuo != null)
            {
                _repository.Delete(residuo);
            }
        }

        public IEnumerable<ResiduoColetaModel> ListarResiduos()
        {
            return _repository.GetAll();
        }

        public ResiduoColetaModel ObterResiduosPorId(int id)
        {
            return _repository.GetById(id);
        }
    }
}

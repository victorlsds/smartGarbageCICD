using vstudy.smartgarbage.Data.Repository.Interface;
using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.Service.Interface;

namespace vstudy.smartgarbage.Service.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public void AtualizarUsuarios(UsuarioModel agendamentoColeta)
        {
            _repository.Update(agendamentoColeta);
        }

        public void CriarUsuarios(UsuarioModel agendamentoColeta)
        {
            _repository.Add(agendamentoColeta);
        }

        public void DeletarUsuarios(int id)
        {
            var usuario = _repository.GetById(id);
            if (usuario != null)
            {
                _repository.Delete(usuario);
            }
        }

        public IEnumerable<UsuarioModel> ListarUsuarios()
        {
            return _repository.GetAll();
        }

        public UsuarioModel ObterUsuariosPorId(int id)
        {
            return _repository.GetById(id);
        }
    }
}

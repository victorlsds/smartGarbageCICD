using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Service.Interface
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioModel> ListarUsuarios();
        UsuarioModel ObterUsuariosPorId(int id);
        void CriarUsuarios(UsuarioModel agendamentoColeta);
        void AtualizarUsuarios(UsuarioModel agendamentoColeta);
        void DeletarUsuarios(int id);
    }
}

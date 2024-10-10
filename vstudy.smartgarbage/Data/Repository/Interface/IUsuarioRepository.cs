using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Data.Repository.Interface
{
    public interface IUsuarioRepository
    {
        IEnumerable<UsuarioModel> GetAll();
        UsuarioModel GetById(int id);
        void Add(UsuarioModel usuario);
        void Update(UsuarioModel usuario);
        void Delete(UsuarioModel usuario);
    }
}

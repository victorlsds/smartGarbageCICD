using vstudy.smartgarbage.Data.Repository.Interface;
using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.Service.Interface;

namespace vstudy.smartgarbage.Data.Repository.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _repo;
        private List<UsuarioModel> _users;

        public AuthService(IUsuarioRepository repo)
        {
            _repo = repo;
            _users = _repo.GetAll().ToList();
        }

        public UsuarioModel Authenticate(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Email == username && u.Senha == password);
        }
    }
}

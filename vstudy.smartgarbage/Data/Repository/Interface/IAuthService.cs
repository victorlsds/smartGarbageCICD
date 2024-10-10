using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Data.Repository.Interface
{
    public interface IAuthService
    {
        UsuarioModel Authenticate(string username, string password);

    }
}

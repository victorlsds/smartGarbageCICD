using vstudy.smartgarbage.Data.Context;
using vstudy.smartgarbage.Data.Repository.Interface;
using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Data.Repository.Implementation
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext _context;
        public UsuarioRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(UsuarioModel usuario)
        {
            _context.Usuario.Add(usuario);
        }

        public void Delete(UsuarioModel usuario)
        {
            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<UsuarioModel> GetAll()
        {
            return _context.Usuario.ToList();
        }

        public UsuarioModel GetById(int id)
        {
            return _context.Usuario.Find(id);
        }

        public void Update(UsuarioModel usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();
        }
    }
}

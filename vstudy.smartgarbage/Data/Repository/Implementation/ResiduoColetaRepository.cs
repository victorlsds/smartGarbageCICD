using vstudy.smartgarbage.Data.Context;
using vstudy.smartgarbage.Data.Repository.Interface;
using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Data.Repository.Implementation
{
    public class ResiduoColetaRepository : IResiduoColetaRepository
    {
        private readonly DatabaseContext _context;
        public ResiduoColetaRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(ResiduoColetaModel residuo)
        {
            _context.ResiduoColeta.Add(residuo);
            _context.SaveChanges();
        }

        public void Delete(ResiduoColetaModel residuo)
        {
            _context.ResiduoColeta.Remove(residuo);
            _context.SaveChanges();
        }

        public IEnumerable<ResiduoColetaModel> GetAll()
        {
            return _context.ResiduoColeta.ToList();
        }

        public ResiduoColetaModel GetById(int id)
        {
            return _context.ResiduoColeta.Find(id);
        }

        public void Update(ResiduoColetaModel residuo)
        {
            _context.Update(residuo);
            _context.SaveChanges();
        }
    }
}

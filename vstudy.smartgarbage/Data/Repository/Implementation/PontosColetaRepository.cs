using vstudy.smartgarbage.Data.Context;
using vstudy.smartgarbage.Data.Repository.Interface;
using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Data.Repository.Implementation
{
    public class PontosColetaRepository : IPontosColetaRepository
    {
        private readonly DatabaseContext _context;
        public PontosColetaRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public void Add(PontosColetaModel pontoColeta)
        {
            _context.PontoColeta.Add(pontoColeta);
        }

        public void Delete(PontosColetaModel pontoColeta)
        {
            _context.PontoColeta.Remove(pontoColeta);
            _context.SaveChanges();
        }

        public IEnumerable<PontosColetaModel> GetAll()
        {
            return _context.PontoColeta.ToList();
        }

        public PontosColetaModel GetById(int id)
        {
            return _context.PontoColeta.Find(id);
        }

        public void Update(PontosColetaModel pontoColeta)
        {
            _context.Update(pontoColeta);
            _context.SaveChanges();
        }
    }
}

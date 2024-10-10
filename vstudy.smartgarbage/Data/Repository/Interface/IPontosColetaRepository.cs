using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Data.Repository.Interface
{
    public interface IPontosColetaRepository
    {
        IEnumerable<PontosColetaModel> GetAll();
        PontosColetaModel GetById(int id);
        void Add(PontosColetaModel pontoColeta);
        void Update(PontosColetaModel pontoColeta);
        void Delete(PontosColetaModel pontoColeta);
    }
}

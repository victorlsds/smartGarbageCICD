using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Data.Repository.Interface
{
    public interface IResiduoColetaRepository
    {
        IEnumerable<ResiduoColetaModel> GetAll();
        ResiduoColetaModel GetById(int id);
        void Add(ResiduoColetaModel residuo);
        void Update(ResiduoColetaModel residuo);
        void Delete(ResiduoColetaModel residuo);
    }
}

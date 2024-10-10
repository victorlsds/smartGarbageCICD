using vstudy.smartgarbage.Data.Repository.Interface;
using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.Service.Interface;

namespace vstudy.smartgarbage.Service.Implementation
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repository;
        public FeedbackService(IFeedbackRepository repository)
        {
            _repository = repository;
        }
        public void AtualizarFeedbacks(FeedbackModel feedback)
        {
            _repository.Update(feedback);
        }

        public void CriarFeedbacks(FeedbackModel feedback)
        {
            _repository.Add(feedback);
        }

        public void DeletarFeedbacks(int id)
        {
            var feedback = _repository.GetById(id);
            if (feedback != null)
            {
                _repository.Delete(feedback);
            }
        }

        public IEnumerable<FeedbackModel> ListarFeedbacks()
        {
            return _repository.GetAll();
        }

        public FeedbackModel ObterFeedbacksPorId(int id)
        {
            return _repository.GetById(id);
        }
    }
}

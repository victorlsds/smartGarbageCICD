using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Service.Interface
{
    public interface IFeedbackService
    {
        IEnumerable<FeedbackModel> ListarFeedbacks();
        FeedbackModel ObterFeedbacksPorId(int id);
        void CriarFeedbacks(FeedbackModel feedback);
        void AtualizarFeedbacks(FeedbackModel feedback);
        void DeletarFeedbacks(int id);
    }
}

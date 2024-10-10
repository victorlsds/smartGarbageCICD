using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Data.Repository.Interface
{
    public interface IFeedbackRepository
    {
        IEnumerable<FeedbackModel> GetAll();
        FeedbackModel GetById(int id);
        void Add(FeedbackModel feedback);
        void Update(FeedbackModel feedback);
        void Delete(FeedbackModel feedback);
    }
}

using Microsoft.EntityFrameworkCore;
using vstudy.smartgarbage.Data.Context;
using vstudy.smartgarbage.Data.Repository.Interface;
using vstudy.smartgarbage.Model;

namespace vstudy.smartgarbage.Data.Repository.Implementation
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DatabaseContext _context;
        public FeedbackRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(FeedbackModel feedback)
        {
            _context.Feedback.Add(feedback);
            _context.SaveChanges();
        }

        public void Delete(FeedbackModel feedback)
        {
            _context.Feedback.Remove(feedback);
            _context.SaveChanges();
        }

        public IEnumerable<FeedbackModel> GetAll()
        {
            return _context.Feedback
               .Include(c => c.Usuario)
               .Include(d => d.AgendamentoColetaLixo)
               .ToList();
        }

        public FeedbackModel GetById(int id)
        {
            return _context.Feedback
               .Include(c => c.Usuario)
               .Include(d => d.AgendamentoColetaLixo)
               .FirstOrDefault(c => c.FeedBackId == id);
        }

        public void Update(FeedbackModel feedback)
        {
            _context.Update(feedback);
            _context.SaveChanges();
        }
    }
}

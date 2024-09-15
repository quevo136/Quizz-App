using Quizz_App.Context;

namespace Quizz_App.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly AppDbContext _context;

        public QuestionService(AppDbContext context)
        {
            _context = context;
        }

        public bool QuestionExists(string questionText)
        {
            return _context.Questions.Any(q => q.Text.ToLower() == questionText.ToLower());
        }
    }
}

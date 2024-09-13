using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizz_App.Context;
using Quizz_App.Models;

namespace Quizz_App.Pages
{
    public class QuestionsModel : PageModel
    {
        public List<Question> Questions { get; set; }

        private AppDbContext _context { get; set; }
        public QuestionsModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Questions = _context.Questions.ToList();

        }
    }
}

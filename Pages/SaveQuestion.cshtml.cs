using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizz_App.Context;
using Quizz_App.Models;

namespace Quizz_App.Pages
{
    public class SaveQuestionModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Question Question { get; set; }

        public SaveQuestionModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            Question = _context.Questions.FirstOrDefault(q => q.Id == id);
            if (Question == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == Question.Id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Update(question);
            _context.SaveChanges();

            return RedirectToPage("/Questions");
        }
    }
}

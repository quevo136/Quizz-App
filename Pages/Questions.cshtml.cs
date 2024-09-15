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


        //edit and save function 
        public IActionResult OnPostEdit(Question question)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingQuestion = _context.Questions.FirstOrDefault(q => q.Id == question.Id);
            if (existingQuestion == null)
            {
                return NotFound();
            }

            existingQuestion.Text = question.Text;
            existingQuestion.Correctans = question.Correctans;
            existingQuestion.Option1 = question.Option1;
            existingQuestion.Option2 = question.Option2;
            existingQuestion.Option3 = question.Option3;

            _context.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var question = _context.Questions.FirstOrDefault(q => q.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            _context.SaveChanges();

            return RedirectToPage();
        }
    }
}

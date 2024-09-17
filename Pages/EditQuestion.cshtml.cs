using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizz_App.Context;
using Quizz_App.Models;

namespace Quizz_App.Pages
{
    public class EditQuestionsModel : PageModel
    {
        //public List<Question> Questions { get; set; }
        private readonly AppDbContext _context;
        [BindProperty]
        public Question Question { get; set; }
        public EditQuestionsModel(AppDbContext context)
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

        public async Task<IActionResult> OnPostEdit(Question question)
        {

            var value = $"{question.Text}";
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

            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }


        //public IActionResult OnPostDelete(int id)
        //{
        //    var question = _context.Questions.FirstOrDefault(q => q.Id == id);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Questions.Remove(question);
        //    _context.SaveChanges();

        //    return RedirectToPage();
        //}
    }
}

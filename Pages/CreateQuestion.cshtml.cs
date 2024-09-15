using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Quizz_App.Context;
using Quizz_App.Models;
using Quizz_App.Services;

namespace Quizz_App.Pages
{
    public class CreateQuestionModel : PageModel
    {
        private readonly AppDbContext _service;
        private readonly IQuestionService _questionService;
        [BindProperty]
        public Question Question { get; set; }

        //public CreateQuestionModel(AppDbContext service)
        //{
        //    _service = service ?? throw new ArgumentNullException(nameof(service));
        //}
        public CreateQuestionModel(AppDbContext service, IQuestionService questionService)
        {
            _service = service;
            _questionService = questionService;
        }
        public void OnGet() {}

        public IActionResult OnPost()
        {
            var value = $"{Question.Text}";

            if (!ModelState.IsValid)
            {
                //return Redirect("/Index");
                return Page();
            }

            if (_questionService.QuestionExists(Question.Text))
            {
                ModelState.AddModelError(string.Empty, "A question with the same text already exists.");
                return Page();
            }


            _service.Add(Question);

            _service.SaveChanges();
            
            return Redirect("/Questions"); // Adjust to your needs
        }
    }
}

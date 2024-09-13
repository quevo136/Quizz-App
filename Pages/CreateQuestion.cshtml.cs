using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quizz_App.Context;
using Quizz_App.Models;

namespace Quizz_App.Pages
{
    public class CreateQuestionModel : PageModel
    {
        private readonly AppDbContext _service;

        [BindProperty]
        public Question Question { get; set; }

        public CreateQuestionModel(AppDbContext service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void OnGet()
        {}

        public IActionResult OnPost()
        {
            var value = $"{Question.Text}";

            if (!ModelState.IsValid)
            {
                //return Redirect("/Index");
                return Page();
            }

            if (Question == null)
            {
                Console.WriteLine("Question is null.");

                return Page(); // Return the page if `Question` is null to avoid null reference exception
            }
            if (_service == null)
            {
                // Log this information
                Console.WriteLine("Service is null.");
                return Page();
            }

            _service.Add(Question);

            _service.SaveChanges();
            
            return Redirect("/Index"); // Adjust to your needs
        }
    }
}

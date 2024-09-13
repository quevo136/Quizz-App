using System.ComponentModel.DataAnnotations;

namespace Quizz_App.Models
{
    public class Question
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required] 
        public string Option1 { get; set; }
        [Required] 
        public string Option2 { get; set; }
        [Required] 
        public string Option3 { get; set; }
        [Required] 
        public string Correctans { get; set; }
    }
}

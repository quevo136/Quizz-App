using Microsoft.EntityFrameworkCore;
using Quizz_App.Models;

namespace Quizz_App.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Question> Questions { get; set; }
        public bool QuestionExists(string questionText)
        {
            return Questions.Any(q => q.Text.Equals(questionText, StringComparison.OrdinalIgnoreCase));
        }

    }
}

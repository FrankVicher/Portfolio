using ElementarySchoolQuizzer.Data.Configurations;
using ElementarySchoolQuizzer.Data.Models;
using Microsoft.EntityFrameworkCore;
using ElementarySchoolQuizzer.Models;

namespace ElementarySchoolQuizzer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Quizz> Quizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Quizz>(new QuizzConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ElementarySchoolQuizzer.Models.QuizzViewModel> QuizzViewModel { get; set; }
    }
}

using GeneralInformationGame.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeneralInformationGame.Shared.Data
{
    public class GameDbContext: IdentityDbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //    "Server = WIN-PUD9TJSCPQ8\\SQLEXPRESS;Database = GeneralInformationGame;Trusted_Connection = True;"
            //    );
            optionsBuilder.UseSqlServer(
               "Server = .;Database = GeneralInformationGame;Trusted_Connection = True;"
               );
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>()
                .HasMany<Question>(s => s.Questions)
                .WithMany(c => c.Games)
                .UsingEntity("GameQuestion",
                l => l.HasOne(typeof(Game)).WithMany().HasForeignKey("GamesId").HasPrincipalKey(nameof(Game.Id)),
                r => r.HasOne(typeof(Question)).WithMany().HasForeignKey("QuestionsId").HasPrincipalKey(nameof(Question.Id)),
                j => j.HasKey("QuestionsId", "GamesId")
                );
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }

    }
}

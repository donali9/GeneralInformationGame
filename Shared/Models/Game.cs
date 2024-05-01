using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GeneralInformationGame.Shared.Models
{
    public class Game
    {
        public Game()
        {
            this.Questions = new HashSet<Question>();
        }
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public int QuestionCount { get; set; }

        public string UserId { get; set; }
        public ICollection<Participant>? Participants { get; set; }
        [JsonIgnore]
        public ICollection<Question> Questions { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public IdentityUser? User { get; set; }
    }
}

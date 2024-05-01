using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GeneralInformationGame.Shared.Models
{
    public class Question
    {
        public Question()
        {
            this.Games = new HashSet<Game>();
        }
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public int Duration { get; set; }
        [Required]
        public string? Answer { get; set; }
        public string? Picture { get; set; }
        [Required]
        public int TypeId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public ICollection<Game> Games { get; set; }

        [ForeignKey("CategoryId")]
        [JsonIgnore]
        public QuestionCategory? Category { get; set; }
        [ForeignKey("TypeId")]
        [JsonIgnore]
        public QuestionType? Type { get; set; }

    }
}

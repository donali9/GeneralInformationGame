using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeneralInformationGame.Shared.Models
{
    public class Participant
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int GameId { get; set; }
        public int Score { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
        [JsonIgnore]
        public virtual Game? Game { get; set; }
    }
}

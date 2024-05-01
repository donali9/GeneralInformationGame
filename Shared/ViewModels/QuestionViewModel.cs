using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralInformationGame.Shared.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Duration { get; set; }
        public string? Answer { get; set; }
        public string? Picture { get; set; }
        public string? CategoryTitle { get; set; }
        public string? ParticipantName { get; set; }
        public bool? IsCorrect { get; set; }
        public int GameId { get; set; }
        public int ParticipantId { get; set; }
    }
}

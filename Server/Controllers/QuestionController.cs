using GeneralInformationGame.Client.Pages;
using GeneralInformationGame.Server.Contracts;
using GeneralInformationGame.Shared;
using GeneralInformationGame.Shared.Models;
using GeneralInformationGame.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralInformationGame.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionRepository _questionRepository;
        public QuestionController(IUnitOfWork unitOfWork, IQuestionRepository questionRepository)
        {
            this._unitOfWork = unitOfWork;
            this._questionRepository = questionRepository;
        }
        //public QuestionController(IUnitOfWork unitOfWork)
        //{
        //    this._unitOfWork = unitOfWork;
        //}
        [HttpGet("{id:int}")]
        public async Task<QuestionViewModel?> GetQuestion(int id)
        {
            var question = await _questionRepository.GetRandomQuestion(id);
            var game = _unitOfWork.Games.Get(g => g.Id == id, i => i.Include(c => c.Participants).Include(c=>c.Questions));
            var nextUser = game.Participants.OrderBy(o => o.CorrectAnswers + o.IncorrectAnswers).ThenBy(o => o.Id).FirstOrDefault();
            game.Questions.Add(question);
            QuestionViewModel questionViewModel = new QuestionViewModel()
            {
                Id = question.Id,
                Answer = question.Answer,
                CategoryTitle = question.Category.Title,
                Title = question.Title,
                Duration = question.Duration,
                GameId = id,
                Picture = question.Picture!=null?question.Picture:"nophoto.jpg",
                ParticipantId = nextUser.Id,
                ParticipantName = nextUser.Name,
                IsCorrect = false,
            };
            _unitOfWork.Complete();
            return questionViewModel;
        }
        
    }
}

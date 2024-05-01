using GeneralInformationGame.Server.Contracts;
using GeneralInformationGame.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeneralInformationGame.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParticipantController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        [HttpPost]
        public ActionResult<Participant> AddParticipant(Participant item)
        {
            var sameParticipant = _unitOfWork.Participants.Get(g=>g.GameId == item.GameId && g.Name == item.Name);
            if(sameParticipant != null)
            {
                return BadRequest("Name already exists.");
            }
            Participant participant = new Participant()
            {
                GameId = item.GameId,
                Name = item.Name,
                Score = 0,
                CorrectAnswers = 0,
                IncorrectAnswers = 0,
            };
            _unitOfWork.Participants.Add(participant);
            _unitOfWork.Complete();
            return Ok(participant);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteParticipant(int id)
        {
            var participant = _unitOfWork.Participants.Get(g => g.Id == id);
            if(participant != null)
            {
                _unitOfWork.Participants.Remove(participant);
                _unitOfWork.Complete();
            }
            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<bool> Putarticipant(int id, [FromBody]bool isCorrect)
        {
            var participant = _unitOfWork.Participants.Get(g => g.Id == id);
            if(participant != null)
            {
                if(isCorrect)
                {
                    participant.CorrectAnswers += 1;
                }
                else
                {
                    participant.IncorrectAnswers += 1;
                }
                participant.Score = participant.CorrectAnswers - (int)(participant.IncorrectAnswers / 3);
                _unitOfWork.Participants.Update(participant);
            }
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}

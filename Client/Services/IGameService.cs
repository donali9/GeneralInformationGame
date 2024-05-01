using GeneralInformationGame.Shared.Models;
using GeneralInformationGame.Shared.ViewModels;

namespace GeneralInformationGame.Client.Services
{
    public interface IGameService
    {
        Task<Game?> AddGame(Game newGame);
        Task<Game?> ShowGame(int id,string email);
        Task<Participant?> AddParticipant(Participant participant);
        Task RemoveParticipant(int id);
        Task<QuestionViewModel?> ShowQuestion(int gameId);
        Task SaveQuestionResult(bool result,int participantId);
        Task<List<Game>> GetAllGames(int page,int size, string email);
        Task<int> GetGamesCount(string email);
    }
}

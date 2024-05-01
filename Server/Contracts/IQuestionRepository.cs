using GeneralInformationGame.Shared.Models;

namespace GeneralInformationGame.Server.Contracts
{
    public interface IQuestionRepository:IRepository<Question>
    {
        Task<Question> GetRandomQuestion(int gameId);
    }
}

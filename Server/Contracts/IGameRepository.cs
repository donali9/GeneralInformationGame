using GeneralInformationGame.Shared.Models;

namespace GeneralInformationGame.Server.Contracts
{
    public interface IGameRepository:IRepository<Game>
    {
        Task<string> GetUserID(string userMail);
    }
}

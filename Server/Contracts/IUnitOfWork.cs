namespace GeneralInformationGame.Server.Contracts
{
    public interface IUnitOfWork:IDisposable
    {
        IGameRepository Games { get; }
        IParticipantRepository Participants { get; }
        IQuestionRepository Question { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}

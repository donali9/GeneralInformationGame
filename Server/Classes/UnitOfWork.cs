using GeneralInformationGame.Server.Contracts;
using GeneralInformationGame.Shared.Data;
using GeneralInformationGame.Server.Repositories;

namespace GeneralInformationGame.Server.Classes
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly GameDbContext Context;
        public UnitOfWork(GameDbContext context)
        {
            this.Context = context;
        }

        public IGameRepository Games => new GameRepository(this.Context);
        public IParticipantRepository Participants => new ParticipantRepository(this.Context);

        public IQuestionRepository Question => new QuestionRepository(this.Context);

        public int Complete()
        {
            return this.Context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await this.Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}

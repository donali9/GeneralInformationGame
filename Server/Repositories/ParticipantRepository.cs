using GeneralInformationGame.Server.Contracts;
using GeneralInformationGame.Shared.Data;
using GeneralInformationGame.Shared.Models;

namespace GeneralInformationGame.Server.Repositories
{
    public class ParticipantRepository : Repository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(GameDbContext dbContext) : base(dbContext)
        {
        }
    }
}

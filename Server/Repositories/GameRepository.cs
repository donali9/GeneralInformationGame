using GeneralInformationGame.Server.Contracts;
using GeneralInformationGame.Shared.Data;
using GeneralInformationGame.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GeneralInformationGame.Server.Repositories
{
    public class GameRepository:Repository<Game>,IGameRepository
    {
        GameDbContext _context;
        public GameRepository(GameDbContext context):base(context)
        {
            this._context = context;
        }
        public async Task<string> GetUserID(string userMail)
        {
            var user = await _context.Users.FirstOrDefaultAsync(f => f.Email == userMail);
            if(user != null)
            {
                return user.Id;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}

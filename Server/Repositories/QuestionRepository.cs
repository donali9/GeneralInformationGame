using GeneralInformationGame.Server.Contracts;
using GeneralInformationGame.Shared.Data;
using GeneralInformationGame.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GeneralInformationGame.Server.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        GameDbContext _context;
        public QuestionRepository(GameDbContext dbContext) : base(dbContext)
        {
            this._context = dbContext;
        }

        public async Task<Question> GetRandomQuestion(int gameId)
        {
            var olds = await _context.Games.Include(i => i.Questions).FirstOrDefaultAsync(f => f.Id == gameId);
            var oldQuestions = olds.Questions.ToList();
            var rand = new Random();
            var questionList = _context.Questions.Include(i=>i.Category).Where(q => !oldQuestions.Contains(q)).ToList();
            var quest = questionList.ElementAt(rand.Next(questionList.Count()));
            return quest;
        }
    }
}

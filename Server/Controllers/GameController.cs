using GeneralInformationGame.Server.Contracts;
using GeneralInformationGame.Shared;
using GeneralInformationGame.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralInformationGame.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameRepository _gameRepository;
        private readonly ILogger<GameController> _logger;
        public GameController(IUnitOfWork unitOfWork, ILogger<GameController> logger, IGameRepository gameRepository)
        {
            this._unitOfWork = unitOfWork;
            this._gameRepository = gameRepository;
            _logger = logger;
        }


        //public async Task<Game> PostGame(Sender sender)
        //{
        //    var newGame = new Game();
        //    var addedGame = await _unitOfWork.Games.AddAsync(newGame);
        //    _unitOfWork.Complete();
        //    return addedGame;
        //}

        [HttpPost]
        public async Task<Game> AddItem([FromBody] Game game)
        {
            try
            {
                var userId = await _gameRepository.GetUserID(game.UserId);
                game.UserId = userId;
                await _unitOfWork.Games.AddAsync(game);
                await _unitOfWork.CompleteAsync();
                return game;
            }
            catch (Exception ex)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                return null;
            }
            
        }
        [Authorize]
        [HttpGet("{id}/{email}")]
        public Game? GetGame(int id, string email)
        {
            var game = _unitOfWork.Games.Get(d => d.Id == id, i => i.Include(c => c.Participants).Include(c => c.Questions));
            //int gameId = 2;
            //if(game!=null) gameId = game.Id;
            return game;
            //return game;
            //return new Game();
        }

        [HttpGet("{page}/{size}/{email}")]
        public async Task<List<Game>> GetAllGame(int page,int size,string email)
        {
            var userId = await _gameRepository.GetUserID(email);
            var allGames = _unitOfWork.Games.Find(f=>f.UserId == userId);
            var result = allGames.OrderByDescending(o=>o.Id).Skip((page-1) * size).Take(size).ToList();
            return result;
        }
        [HttpGet("{email}")]
        public async Task<int> GetGamesNumber(string email)
        {
            var userId = await _gameRepository.GetUserID(email);
            var allGames = _unitOfWork.Games.Find(f => f.UserId == userId);
            return allGames.Count();
        }
    }
}

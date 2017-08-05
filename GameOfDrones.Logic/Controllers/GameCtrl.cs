using GameOfDrones.Domain.DAL;
using GameOfDrones.Domain.Entities;
using GameOfDrones.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Logic.Controllers
{
    public class GameCtrl
    {
        private UnitOfWork uow { get; set; }
        private IRepository<Game> repGames { get; set; }
        private IRepository<Player> repPlayers { get; set; }
        private IRepository<Score> repScores { get; set; }

        public GameCtrl()
        {
            uow = new UnitOfWork();
            repGames = uow.Repository<Game>();
            repPlayers = uow.Repository<Player>();
            repScores = uow.Repository<Score>();
        }

        public IEnumerable<GameDTO> GetAll()
        {
            var result = new List<GameDTO>();
            var games = repGames.GetAll().Include(x => x.Scores).ToList();//.
            foreach (var game in games)
                result.Add(new GameDTO {
                    ID = game.ID,
                    Date = game.Date,
                    Player1 = game.Scores[0].Player.Name,
                    Player2 = game.Scores[1].Player.Name
                });

            return result;
        }

        public GameDTO Get(int id)
        {
            var game = repGames.Get(x => x.ID == id);
            GameDTO dto = new GameDTO
            {
                Date = game.Date,
                Player1 = game.Scores[0].Player.Name,
                Player2 = game.Scores[1].Player.Name
            };
            return dto;
        }

        public int Add(GameDTO dto)
        {
            var playerCtrl = new PlayerCtrl(uow);
            var player1 = playerCtrl.Add(dto.Player1);
            var player2 = playerCtrl.Add(dto.Player2);


            var game = new Game();
            repGames.Add(game);


            var score1 = new Score { Game = game, PlayerId = player1 };
            repScores.Add(score1);

            var score2 = new Score { Game = game, PlayerId = player2 };
            repScores.Add(score2);

            repGames.Add(game);
            uow.SaveChanges();
            return game.ID;
        }

    }
}

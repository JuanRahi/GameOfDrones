using GameOfDrones.Domain.DAL;
using GameOfDrones.Domain.Entities;
using GameOfDrones.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Logic.Controllers
{
    public class PlayerCtrl
    {
        private UnitOfWork uow { get; set; }
        private IRepository<Player> repPlayers { get; set; }
        private IRepository<Score> repScores { get; set; }

        public PlayerCtrl()
        {
            uow = new UnitOfWork();
            repPlayers = uow.Repository<Player>();
            repScores = uow.Repository<Score>();
        }

        public PlayerCtrl(UnitOfWork uow)
        {
            this.uow = uow;
            repPlayers = uow.Repository<Player>();
        }
        
        public IEnumerable<PlayerDTO> GetAll()
        {
            var result = new List<PlayerDTO>();
            var players = repPlayers.GetAll();
            foreach (var player in players)
                result.Add(new PlayerDTO { ID = player.ID, Name = player.Name });

            return result;
        }

        public PlayerDTO Get(int id)
        {
            var player = repPlayers.Get(x => x.ID == id);
            PlayerDTO dto = new PlayerDTO
            {                
                ID = player.ID,
                Name = player.Name
            };
            return dto;
        }

        public FullPlayerDTO GetWins(int id, int offset)
        {
            var player = repPlayers.Get(x => x.ID == id);

            FullPlayerDTO dto = new FullPlayerDTO(player.Name);
            var statistics = new List<StatisticDTO>();
            var scores = repScores.GetAll(x => x.PlayerId == id && x.Wins == 3).Skip(offset).Take(10).ToList();
            foreach (var score in scores)
            {
                var vsScore = (score.Game.Scores[0] == score) ? score.Game.Scores[1] : score.Game.Scores[0];
                var statistic = new StatisticDTO
                {
                    Vs = vsScore.Player.Name,
                    Result = string.Format("3 a {0}", vsScore.Wins),
                    Date = vsScore.Game.StartDate.ToString("yyyy-MM-dd hh:mm")
                };
                statistics.Add(statistic);
            }

            dto.Statistics = statistics;
            return dto;
        }

        public int Add(PlayerDTO dto)
        {
            return Add(dto.Name);
        }

        public int Add(string name)
        {
            var player = repPlayers.Get(x => x.Name == name);
            if (player == null)
            {
                player = new Player { Name = name };
                repPlayers.Add(player);
                uow.SaveChanges();
            }
            return player.ID;
        }
    }
}

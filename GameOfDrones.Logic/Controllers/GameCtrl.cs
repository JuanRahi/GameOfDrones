using GameOfDrones.Domain.DAL;
using GameOfDrones.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Logic.Controllers
{
    public class GameCtrl
    {
        private GameOfDronesContext db { get; set; }

        public GameCtrl()
        {
            db = new GameOfDronesContext();
        }

        public List<GameDTO> GetAll()
        {
            var result = new List<GameDTO>();
            foreach (var game in db.Games.ToList())
                result.Add(new GameDTO { Player1 = game.Scores[0].Player.Nombre, Player2 = game.Scores[1].Player.Nombre });

            return result;
        }

    }
}

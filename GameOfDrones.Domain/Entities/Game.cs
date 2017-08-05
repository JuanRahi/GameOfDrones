using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.Entities
{
    public class Game
    {
        public int ID { get; set; }
        public Score ScorePlayer1 { get; set; }
        public Score ScorePlayer2 { get; set; }

        public List<Round> Rounds { get; set; }
    }
}

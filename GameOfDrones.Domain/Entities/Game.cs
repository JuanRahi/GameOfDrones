using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.Entities
{
    public class Game
    {
        public Game()
        {
            //Scores = new List<Score>();
            //Rounds = new List<Round>();
            Date = DateTime.Now;           
        }

        public int ID { get; set; }
        public DateTime Date { get; set; }

        public virtual List<Score> Scores { get; set; }
        public virtual List<Round> Rounds { get; set; }
    }
}

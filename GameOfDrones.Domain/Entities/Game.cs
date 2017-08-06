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
            StartDate = DateTime.Now;           
        }

        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual List<Score> Scores { get; set; }
        public virtual List<Round> Rounds { get; set; }
    }
}

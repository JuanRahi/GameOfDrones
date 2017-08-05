using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.Entities
{
    public class Score
    {
        public int ID { get; set; }
        public Player Player { get; set; }
        public int Wins { get; set; }

        public Game Game { get; set; }        
    }
}

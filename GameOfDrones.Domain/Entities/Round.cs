using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.Entities
{
    public class Round
    {
        public int ID { get; set; }
        public Game Game { get; set; }
        public Player Winner { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.Entities
{
    public class Player
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public List<Score> Scores { get; set; }
    }
}

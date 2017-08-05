using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.Entities
{
    public class Round
    {
        public int ID { get; set; }

        [Required]
        public int GameId { get; set; }
        public int WinnerId { get; set; }
        
        public virtual Game Game { get; set; }
        public virtual Player Winner { get; set; }
    }
}

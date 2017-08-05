using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.Entities
{
    public class Score
    {
        public int ID { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int GameId { get; set; }
        public int Wins { get; set; }

        
        public virtual Player Player { get; set; }        
        public virtual Game Game { get; set; }        
    }
}

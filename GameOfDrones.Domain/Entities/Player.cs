using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.Entities
{
    public class Player
    {         
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }

        public virtual List<Score> Scores { get; set; }
    }
}

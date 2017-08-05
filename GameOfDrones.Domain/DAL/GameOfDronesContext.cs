using GameOfDrones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Domain.DAL
{
    public class GameOfDronesContext: DbContext
    {
        public GameOfDronesContext() : base("name=GameOfDrones")
        {
            
        }
        
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
    }
}

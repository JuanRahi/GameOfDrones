using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Shared.DTO
{
    public class GameResultDTO
    {
        public GameResultDTO(bool keepPlaying, string winner, int id)
        {
            KeepPlaying = keepPlaying;
            Winner = winner;
            WinnerId = id;
        }

        public bool KeepPlaying { get; set; }
        public string Winner { get; set; }
        public int WinnerId { get; set; }
    }
}

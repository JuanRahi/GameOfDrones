﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Shared.DTO
{
    public class FullGameDTO
    {
        public int ID { get; set; }
        public PlayerDTO Player1 { get; set; }
        public PlayerDTO Player2 { get; set; }
        public List<RoundDTO> Rounds { get; set; }
        public int TotalRounds { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

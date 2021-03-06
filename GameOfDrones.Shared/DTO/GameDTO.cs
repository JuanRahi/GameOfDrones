﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Shared.DTO
{
    public class GameDTO
    {
        public int ID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        public string Player1 { get; set; }
        [Required]
        public string Player2 { get; set; }
        
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameOfDrones.Shared.Utils.EnumHelper;

namespace GameOfDrones.Shared.DTO
{
    public class PlayerDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Play Play { get; set; }
    }
}

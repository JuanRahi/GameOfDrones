using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Shared.DTO
{
    public class FullPlayerDTO
    {
        public FullPlayerDTO(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<StatisticDTO> Statistics { get; set; }
    }
}

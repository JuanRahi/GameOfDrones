using GameOfDrones.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameOfDrones.Shared.Utils.EnumHelper;

namespace GameOfDrones.Shared.Utils
{
    public class CompareHelper
    {
        public static int Winner(PlayerDTO player1, PlayerDTO player2)
        {
            switch (player1.Play)
            {
                case Play.Paper:
                    return (player2.Play == Play.Rock) ? player1.ID : player2.ID;
                case Play.Rock:
                    return (player2.Play == Play.Scissors) ? player1.ID : player2.ID;
                case Play.Scissors:
                    return (player2.Play == Play.Paper) ? player1.ID : player2.ID;
            }

            return 0; // ERROR
        }
    }
}

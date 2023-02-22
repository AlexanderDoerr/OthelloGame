using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloGame
{
    internal class Game
    {
        public Game()
        {
            //fill middle of board with pieces
            board[3, 3] = board[4, 4] = Colors.black;
            board[3, 4] = board[4, 3] = Colors.white;
        }

        //create 8x8 array
        public Colors[,] board { get; set; } = new Colors[8, 8];

        public bool isBlackTurn { get; set; } = true;
    }

    public enum Colors
    {
        black,
        white
    }
}

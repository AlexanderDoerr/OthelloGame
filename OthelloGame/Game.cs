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

        private Colors checkWin()
        {
            int blackCount = 0;
            int whiteCount = 0;

            // count the number of black and white pieces on the board
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == Colors.black)
                    {
                        blackCount++;
                    }
                    else if (board[row, col] == Colors.white)
                    {
                        whiteCount++;
                    }
                }
            }

            // check for a win condition
            if (blackCount > whiteCount)
            {
                return Colors.black;
            }
            else if (whiteCount > blackCount)
            {
                return Colors.white;
            }
            else
            {
                return Colors.empty;
            }
        }

        public bool hasEmptySpaces()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == Colors.empty)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }


    public enum Colors
    {
        black,
        white,
        empty
    }
}

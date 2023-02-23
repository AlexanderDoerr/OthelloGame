using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OthelloGame
{
    /// <summary>
    /// Interaction logic for BoardControl.xaml
    /// </summary>
    public partial class BoardControl : Window
    {

        private Game game;
        public BoardControl()
        {
            InitializeComponent();
            game = new Game();
            updateGrid();
        }

        private void updateGrid()
        {
            //get the board from the game and update the grid
            Colors[,] board = game.board;
            //get the grid from the xaml
            Grid grid = (Grid)FindName("grid");
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col] == Colors.black)
                    {
                        //black
                        //get the image elements from the grid
                        Image img = (Image)grid.Children.Cast<UIElement>().Last(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col);
                        img.Source = new BitmapImage(new Uri("assets/BlackPiece_lg.png", UriKind.Relative));
                    }
                    else if (board[row, col] == Colors.white)
                    {
                        //white
                        Image img = (Image)grid.Children.Cast<UIElement>().Last(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col);
                        img.Source = new BitmapImage(new Uri("assets/WhitePiece_lg.png", UriKind.Relative));
                    }
                    else
                    {
                        //empty
                        Image img = (Image)grid.Children.Cast<UIElement>().Last(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col);
                        img.Source = new BitmapImage(new Uri("assets/EmptyPiece_lg.png", UriKind.Relative));

                    }
                }
            }
                // check for a win
            Colors winner = game.checkWin();
            //Update Score
            Label score = (Label)FindName("lblPlayerScore");
            score.Content = "Black score: " + game.blackCount + " White Score: " + game.whiteCount;
            if (winner != Colors.empty)
            {
                Label output = (Label)FindName("lblGameData");
                output.Content = winner.ToString() + " wins!";
                MessageBox.Show(winner.ToString() + " wins!");
            }
               
        }

        private void flipPieces(int row, int col, string turn)
        {
            //check horizontal vertcial and diagoinal
            //check horizontal vertcial and diagoinal
            if (turn.Equals("black"))
            {
                //check horziontally
                //loop through the row to the right of the piece and find where there is another black piece other than the piece placed,
                //find the first black piece
                //if there is null before the black piece break dont flip pieces, 
                for (int i = col + 1; i < 8; i++)
                {
                    if (game.board[row, i] == Colors.black)
                    {
                        //flip pieces
                        for (int j = col + 1; j < i; j++)
                        {
                            game.board[row, j] = Colors.black;
                        }
                        break;
                    }
                    else if (game.board[row, i] == Colors.empty)
                    {
                        break;
                    }
                }
                //left loop
                for (int i = col - 1; i >= 0; i--)
                {
                    if (game.board[row, i] == Colors.black)
                    {
                        //flip pieces
                        for (int j = col - 1; j > i; j--)
                        {
                            game.board[row, j] = Colors.black;
                        }
                        break;
                    }
                    else if (game.board[row, i] == Colors.empty)
                    {
                        break;
                    }
                }
                //check vertically
                //up loop
                for (int i = row - 1; i >= 0; i--)
                {
                    if (game.board[i, col] == Colors.black)
                    {
                        //flip pieces
                        for (int j = row - 1; j > i; j--)
                        {
                            game.board[j, col] = Colors.black;
                        }
                        break;
                    }
                    else if (game.board[i, col] == Colors.empty)
                    {
                        break;
                    }
                }
                //down loop
                for (int i = row + 1; i < 8; i++)
                {
                    if (game.board[i, col] == Colors.black)
                    {
                        //flip pieces
                        for (int j = row + 1; j < i; j++)
                        {
                            game.board[j, col] = Colors.black;
                        }
                        break;
                    }
                    else if (game.board[i, col] == Colors.empty)
                    {
                        break;
                    }
                }
                //check diagonally "/"
                //up right
                for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--, j++)
                {
                    if (game.board[i, j] == Colors.black)
                    {
                        //flip pieces
                        for (int k = row - 1, l = col + 1; k > i && l < j; k--, l++)
                        {
                            game.board[k, l] = Colors.black;
                        }
                        break;
                    }
                    else if (game.board[i, j] == Colors.empty)
                    {
                        break;
                    }
                }
                //down left
                for (int i = row + 1, j = col - 1; i < 8 && j >= 0; i++, j--)
                {
                    if (game.board[i, j] == Colors.black)
                    {
                        //flip pieces
                        for (int k = row + 1, l = col - 1; k < i && l > j; k++, l--)
                        {
                            game.board[k, l] = Colors.black;
                        }
                        break;
                    }
                    else if (game.board[i, j] == Colors.empty)
                    {
                        break;
                    }
                }
                //check diagonally "\"
                //up left
                for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
                {
                    if (game.board[i, j] == Colors.black)
                    {
                        //flip pieces
                        for (int k = row - 1, l = col - 1; k > i && l > j; k--, l--)
                        {
                            game.board[k, l] = Colors.black;
                        }
                        break;
                    }
                    else if (game.board[i, j] == Colors.empty)
                    {
                        break;
                    }
                }
                //down right
                for (int i = row + 1, j = col + 1; i < 8 && j < 8; i++, j++)
                {
                    if (game.board[i, j] == Colors.black)
                    {
                        //flip pieces
                        for (int k = row + 1, l = col + 1; k < i && l < j; k++, l++)
                        {
                            game.board[k, l] = Colors.black;
                        }
                        break;
                    }
                    else if (game.board[i, j] == Colors.empty)
                    {
                        break;
                    }
                }
            }
            else if (turn.Equals("white"))
            {

                //check horziontally
                //loop through the row to the right of the piece and find where there is another black piece other than the piece placed,
                //find the first black piece
                //if there is null before the black piece break dont flip pieces, 
                for (int i = col + 1; i < 8; i++)
                {
                    if (game.board[row, i] == Colors.white)
                    {
                        //flip pieces
                        for (int j = col + 1; j < i; j++)
                        {
                            game.board[row, j] = Colors.white;
                        }
                        break;
                    }
                    else if (game.board[row, i] == Colors.empty)
                    {
                        break;
                    }
                }
                //left loop
                for (int i = col - 1; i >= 0; i--)
                {
                    if (game.board[row, i] == Colors.white)
                    {
                        //flip pieces
                        for (int j = col - 1; j > i; j--)
                        {
                            game.board[row, j] = Colors.white;
                        }
                        break;
                    }
                    else if (game.board[row, i] == Colors.empty)
                    {
                        break;
                    }
                }
                //check vertically
                //up loop
                for (int i = row - 1; i >= 0; i--)
                {
                    if (game.board[i, col] == Colors.white)
                    {
                        //flip pieces
                        for (int j = row - 1; j > i; j--)
                        {
                            game.board[j, col] = Colors.white;
                        }
                        break;
                    }
                    else if (game.board[i, col] == Colors.empty)
                    {
                        break;
                    }
                }
                //down loop
                for (int i = row + 1; i < 8; i++)
                {
                    if (game.board[i, col] == Colors.white)
                    {
                        //flip pieces
                        for (int j = row + 1; j < i; j++)
                        {
                            game.board[j, col] = Colors.white;
                        }
                        break;
                    }
                    else if (game.board[i, col] == Colors.empty)
                    {
                        break;
                    }
                }
                //check diagonally "/"
                //up right
                for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--, j++)
                {
                    if (game.board[i, j] == Colors.white)
                    {
                        //flip pieces
                        for (int k = row - 1, l = col + 1; k > i && l < j; k--, l++)
                        {
                            game.board[k, l] = Colors.white;
                        }
                        break;
                    }
                    else if (game.board[i, j] == Colors.empty)
                    {
                        break;
                    }
                }
                //down left
                for (int i = row + 1, j = col - 1; i < 8 && j >= 0; i++, j--)
                {
                    if (game.board[i, j] == Colors.white)
                    {
                        //flip pieces
                        for (int k = row + 1, l = col - 1; k < i && l > j; k++, l--)
                        {
                            game.board[k, l] = Colors.white;
                        }
                        break;
                    }
                    else if (game.board[i, j] == Colors.empty)
                    {
                        break;
                    }
                }
                //check diagonally "\"
                //up left
                for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
                {
                    if (game.board[i, j] == Colors.white)
                    {
                        //flip pieces
                        for (int k = row - 1, l = col - 1; k > i && l > j; k--, l--)
                        {
                            game.board[k, l] = Colors.white;
                        }
                        break;
                    }
                    else if (game.board[i, j] == Colors.empty)
                    {
                        break;
                    }
                }
                //down right
                for (int i = row + 1, j = col + 1; i < 8 && j < 8; i++, j++)
                {
                    if (game.board[i, j] == Colors.white)
                    {
                        //flip pieces
                        for (int k = row + 1, l = col + 1; k < i && l < j; k++, l++)
                        {
                            game.board[k, l] = Colors.white;
                        }
                        break;
                    }
                    else if (game.board[i, j] == Colors.empty)
                    {
                        break;
                    }
                }
                //check diagonally "/"
                //up right
                for (int i = row - 1, j = col + 1; i >= 0 && j < 8; i--, j++)
                {
                    if (game.board[i, j] == Colors.white)
                    {
                        //flip pieces
                        for (int k = row - 1, l = col + 1; k > i && l < j; k--, l++)
                        {
                            game.board[k, l] = Colors.white;
                        }
                        break;
                    }
                    else if (game.board[i, j] == Colors.empty)
                    {
                        break;
                    }
                }
                //down left
                for (int i = row + 1, j = col - 1; i < 8 && j >= 0; i++, j--)
                {
                    if (game.board[i, j] == Colors.white)
                    {
                        //flip pieces
                        for (int k = row + 1, l = col - 1; k < i && l > j; k++, l--)
                        {
                            game.board[k, l] = Colors.white;
                        }
                        break;
                    }
                    else if (game.board[i, j] == Colors.empty)
                    {
                        break;
                    }
                }

            }
        }
     

            private void Image_OnMouseMouseDown(object sender, RoutedEventArgs routedEventArgs)
            {
            Button btn = (Button)sender;
            Grid grid = (Grid)btn.Parent;
            int row = Grid.GetRow(btn);
            int col = Grid.GetColumn(btn);
            Image img = (Image)grid.Children.Cast<UIElement>().Last(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col);
            //add piece to game class
            //if we want to check if piece can be played it will be here //strech goal
            if (game.isBlackTurn)
            {
                game.board[row, col] = Colors.black;
                //check for flips here then update game board array before the grid updates
                flipPieces(row, col, "black");
            }
            else
            {
                game.board[row, col] = Colors.white;
                //check for flips here then update game board array before the grid updates
                flipPieces(row, col, "white");
            }
            game.isBlackTurn = !game.isBlackTurn;
            updateGrid();
            btn.IsEnabled = false;
        }


        private void Button_OnMouseEnter(object sender, MouseEventArgs e)
        {
            // We will add code here to check if the move is valid and then change the color of the button
            // to indicate that it is a valid move.
            // for now it will just change the color of the button to gray
            Button btn = (Button)sender;
            if (btn.IsEnabled)
            {
                btn.Background = new SolidColorBrush(System.Windows.Media.Colors.Gray);
            }
        }

        private void Button_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Background = new SolidColorBrush(System.Windows.Media.Colors.Transparent);
        }

        private void BtnNewGame_OnClick(object sender, RoutedEventArgs e)
        {
            game = new Game();
            updateGrid();
            //reset the buttons
            Grid grid = (Grid)FindName("grid");
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    Button btn = (Button)grid.Children.Cast<UIElement>().First(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col);
                    btn.IsEnabled = true;
                }
            }
            //reset output
            Label output = (Label)FindName("lblGameData");
            output.Content = "";
        }

        private void BtnNewGame_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.IsEnabled)
            {
                btn.Background = new SolidColorBrush(System.Windows.Media.Colors.Gray);
            }
        }

        private void BtnNewGame_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Background = new SolidColorBrush(System.Windows.Media.Colors.Transparent);
        }
    }
}


 

using System;
using System.Collections.Generic;
using System.Linq;
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
            if (game.isBlackTurn)
            {
                img.Source = new BitmapImage(new Uri("assets/BlackPiece_lg.png", UriKind.Relative));
                game.board[row, col] = Colors.black;
            }
            else
            {
                img.Source = new BitmapImage(new Uri("assets/WhitePiece_lg.png", UriKind.Relative));
                game.board[row, col] = Colors.white;
            }
            game.isBlackTurn = !game.isBlackTurn;
            //redundant but sure gonna call this anyways
            updateGrid();
        }
    }
}


 

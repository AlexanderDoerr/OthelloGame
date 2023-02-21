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
        }



        private void Image_OnMouseMouseDown(object sender, RoutedEventArgs routedEventArgs)
        {
            Button btn = (Button)sender;
            Grid grid = (Grid)btn.Parent;
            int row = Grid.GetRow(btn);
            int col = Grid.GetColumn(btn);
            Image img = (Image)grid.Children.Cast<UIElement>().Last(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col);
            img.Source = new BitmapImage(new Uri("assets/BlackPiece_lg.png", UriKind.Relative));
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
                btn.Background = new SolidColorBrush(Colors.Gray);
            }
        }

        private void Button_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Background = new SolidColorBrush(Colors.Transparent);
        }
    }
}


 

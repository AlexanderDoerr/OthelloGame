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
        }
    }
}


 

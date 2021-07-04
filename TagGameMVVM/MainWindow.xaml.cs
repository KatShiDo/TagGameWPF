using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TagGameMVVM.Annotations;

namespace TagGameMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Model model = new Model();
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = model;
            //Loaded += MainWindow_Loaded;
        }

        /*private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            model.Init();
        }*/

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var brd = (sender as Border);
            var piece = brd.DataContext as Piece;
            model.PressBy(piece);
        }
    }
}
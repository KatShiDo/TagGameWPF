using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using TagGameLib;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ModelGame model;
        public MainWindow()
        {
            InitializeComponent();
            model = new ModelGame();
            model.RePaint += Model_RePaint;
            model.Init();
        }

        private void Model_RePaint(object sender, int[,] e)
        {
            int[][] map = new int[4][];
            for (int i = 0; i < 4; i++)
            {
                map[i] = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    map[i][j] = model[i, j];
                }
            }

            ic.ItemsSource = map;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var brd = sender as Border;
            var num = (int) brd.DataContext;
            model.Press(num);
        }
    }
}
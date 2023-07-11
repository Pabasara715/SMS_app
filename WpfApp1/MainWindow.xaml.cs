using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            DataContext = new MainWindowVM();
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }
        private bool IsMaximized = false;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                if (IsMaximized) 
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 850;
                    this.Height = 600;

                    this.IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized =true;
                }
            }
        }
    }
}

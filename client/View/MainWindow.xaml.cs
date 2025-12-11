using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using client.ViewModel;
using MaterialIcon = MahApps.Metro.IconPacks.PackIconMaterial;
using MaterialKind = MahApps.Metro.IconPacks.PackIconMaterialKind;

namespace client.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel(this);
            ThemeButton.Content = (DataContext as MainWindowViewModel).ChangeTheme();
        }

        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            ThemeButton.Content = (DataContext as MainWindowViewModel).ChangeTheme();
        }

        private void HeaderBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) Application.Current.MainWindow.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            AdjustWindowSize();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AdjustWindowSize()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                MaxButton.Content = new MaterialIcon() { Kind = MaterialKind.WindowMaximize };
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                MaxButton.Content = new MaterialIcon() { Kind = MaterialKind.WindowRestore };
            }

        }
    }
}
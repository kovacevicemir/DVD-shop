using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DeNiro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            homepage homepage = new homepage();
            MainFrame.NavigationService.Navigate(homepage);
        }

        //Click on home icon
        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            homepage homepage = new homepage();
            MainFrame.NavigationService.Navigate(homepage);
        }

        //Restart app
        private void menu_restart_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        //Escape button handler ::: go back to homepage
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                homepage homepage = new homepage();
                MainFrame.NavigationService.Navigate(homepage);
            }
        }

        //Quit from menu
        private void menu_quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Settings
        private void menu_setting_Click(object sender, RoutedEventArgs e)
        {
            settings settings = new settings();
            settings.Show();
        }
    }
}

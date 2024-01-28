using JollibeeOrderingSystem.Models;
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

namespace JollibeeOrderingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Order Order { get; set; }
        public MainWindow(Order order)
        {
            InitializeComponent();
            Order = order;
        }

        private void Start_Btn(object sender, RoutedEventArgs e) 
        {
            MainMenu mainMenu = new MainMenu(Order);
            mainMenu.Show();
            this.Close();
        }
    }
}
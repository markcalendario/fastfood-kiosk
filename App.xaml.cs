using System.Configuration;
using System.Data;
using System.Windows;
using JollibeeOrderingSystem.Models;

namespace JollibeeOrderingSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(new Order(1));
            mainWindow.Show();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KatalogMuzyczny
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Window LoginUIWindow;
        public static Window MainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

        }
        public static void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}

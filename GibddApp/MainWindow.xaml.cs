using GibddApp.Classes;
using GibddApp.Pages;
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
using GibddApp.Classes;
using GibddApp.Pages;

namespace GibddApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Classes.ClassFrame.frmObj = MainFrame;
            Classes.ClassFrame.frmObj.Navigate(new Pages.PageAuthorize());
        }
    }
}
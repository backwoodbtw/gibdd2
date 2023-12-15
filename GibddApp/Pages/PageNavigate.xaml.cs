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

namespace GibddApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageNavigate.xaml
    /// </summary>
    public partial class PageNavigate : Page
    {
        public PageNavigate()
        {
            InitializeComponent();
        }

        private void BtnViewAll_Click(object sender, RoutedEventArgs e)
        {
            // Логика перехода на страницу PageView
            NavigationService?.Navigate(new PageView());
        }

        private void BtnAddDelete_Click(object sender, RoutedEventArgs e)
        {
            // Логика перехода на страницу PageTry

            NavigationService?.Navigate(new PageAddDelete());
        }
    }
}

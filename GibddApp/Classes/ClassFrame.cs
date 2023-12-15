using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GibddApp.Classes
{
    public static class NavigationService
    {
        private static Frame _frame;

        public static void Initialize(Frame frame)
        {
            _frame = frame;
        }

        public static void NavigateToPage(Page page)
        {
            if (_frame != null)
            {
                _frame.Content = page;
            }
            else
            {
                MessageBox.Show("Frame is not initialized.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    internal class ClassFrame
    {
        public static Frame frmObj;
    }
}
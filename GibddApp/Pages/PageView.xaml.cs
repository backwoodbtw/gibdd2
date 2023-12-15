using GibddApp.Classes;
using System.Data.SqlClient;
using System.Configuration;
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
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;

namespace GibddApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageView.xaml
    /// </summary>
    public partial class PageView : Page
    {
        private GIBDDDatabaseEntities context;


        public PageView()
        {
            InitializeComponent();
            context = new GIBDDDatabaseEntities();

        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = searchTextBox.Text;

            var результат = from водитель in context.Водители
                            join автомобиль in context.Автомобили on водитель.НомерВУ equals автомобиль.Владелец into автомобилиВодителя
                            from авто in автомобилиВодителя.DefaultIfEmpty()
                            join нарушение in context.НарушенияВодителей on водитель.НомерВУ equals нарушение.НомерВУ into нарушенияВодителя
                            from нарушение in нарушенияВодителя.DefaultIfEmpty()
                            join нарушениеПДД in context.НарушенияПДД on нарушение.КодНарушения equals нарушениеПДД.КодНарушения into нарушенияПДД
                            from нарушениеПДД in нарушенияПДД.DefaultIfEmpty()
                            where водитель.ФИО.Contains(searchText) ||
                                  водитель.НомерВУ.Contains(searchText) ||
                                  водитель.Адрес.Contains(searchText) ||
                                  водитель.Телефон.Contains(searchText) ||
                                  авто.Марка.Contains(searchText) || // Добавлено условие для марки автомобиля
                                  нарушениеПДД.ВидНарушения.Contains(searchText) // Добавлено условие для вида нарушения
                            select new НарушениеВодителя
                            {
                                НомерВУ = водитель.НомерВУ,
                                ФИО = водитель.ФИО,
                                Адрес = водитель.Адрес,
                                Телефон = водитель.Телефон,
                                Марка = авто != null ? авто.Марка : null,
                                КодНарушения = нарушение.КодНарушения,
                                ДатаВремяНарушения = нарушение.ДатаВремяНарушения,
                                РайонНарушения = нарушение != null ? нарушение.РайонНарушения : null,
                                ВидНарушения = нарушениеПДД != null ? нарушениеПДД.ВидНарушения : null
                            };

            // Отображаем результат в DataGrid
            dataGrid.ItemsSource = результат.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public class ВодительСМаркой
        {
            public string НомерВУ { get; set; }
            public string ФИО { get; set; }
            public string Адрес { get; set; }
            public string Телефон { get; set; }
            public string Марка { get; set; }
        }

        public class НарушениеВодителя
        {
            public string НомерВУ { get; set; }
            public string ФИО { get; set; }
            public string Адрес { get; set; }
            public string Телефон { get; set; }
            public string Марка { get; set; }
            public int? КодНарушения { get; set; }
            public DateTime? ДатаВремяНарушения { get; set; }
            public string РайонНарушения { get; set; }
            public string ВидНарушения { get; set; }
        }

        private void LoadData()
        {
            using (var context = new GIBDDDatabaseEntities())
            {
                var query = from водитель in context.Водители
                            join автомобиль in context.Автомобили on водитель.НомерВУ equals автомобиль.Владелец into автомобилиВодителя
                            from авто in автомобилиВодителя.DefaultIfEmpty()
                            join нарушение in context.НарушенияВодителей on водитель.НомерВУ equals нарушение.НомерВУ into нарушенияВодителя
                            from нарушение in нарушенияВодителя.DefaultIfEmpty()
                            join нарушениеПДД in context.НарушенияПДД on нарушение.КодНарушения equals нарушениеПДД.КодНарушения into нарушенияПДД
                            from нарушениеПДД in нарушенияПДД.DefaultIfEmpty()
                            select new НарушениеВодителя
                            {
                                НомерВУ = водитель.НомерВУ,
                                ФИО = водитель.ФИО,
                                Адрес = водитель.Адрес,
                                Телефон = водитель.Телефон,
                                Марка = авто != null ? авто.Марка : null,
                                КодНарушения = нарушение.КодНарушения,
                                ДатаВремяНарушения = нарушение.ДатаВремяНарушения,
                                РайонНарушения = нарушение != null ? нарушение.РайонНарушения : null,
                                ВидНарушения = нарушениеПДД != null ? нарушениеПДД.ВидНарушения : null
                            };

                var результат = query.ToList();

                // Отображаем результат в DataGrid
                dataGrid.ItemsSource = результат;
            }
        }
    }
}
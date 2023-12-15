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
    public partial class PageAddDelete : Page
    {
        private GIBDDDatabaseEntities context;

        public PageAddDelete()
        {
            InitializeComponent();
            context = new GIBDDDatabaseEntities();
            LoadData(); // Загрузка данных при инициализации страницы
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Оставить этот метод пустым
        }

        private void LoadData()
        {
            // Загрузка данных из таблицы "Водители"
            var водители = context.Водители.ToList();
            dataGrid.ItemsSource = водители;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение НомерВУ записи для удаления
                string номерВУToDelete = txtBoxIDToDelete.Text;

                // Поиск записи в таблице "Водители" по НомерВУ
                var водитель = context.Водители.FirstOrDefault(v => v.НомерВУ == номерВУToDelete);

                // Если запись найдена, удаляем её
                if (водитель != null)
                {
                    context.Водители.Remove(водитель);
                    context.SaveChanges();
                    MessageBox.Show("Запись успешно удалена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData(); // Обновление DataGrid после удаления
                }
                else
                {
                    MessageBox.Show("Запись с указанным НомерВУ не найдена.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении записи: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создание новой записи "Водитель"
                Водители новыйВодитель = new Водители
                {
                    НомерВУ = txtBoxDriverID.Text,
                    ФИО = txtBoxFIO.Text,
                    Адрес = txtBoxAddress.Text,
                    Телефон = txtBoxPhone.Text
                };

                // Добавление записи в таблицу "Водители"
                context.Водители.Add(новыйВодитель);
                context.SaveChanges();
                MessageBox.Show("Запись успешно добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData(); // Обновление DataGrid после добавления
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace GibddApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorize.xaml
    /// </summary>
    public partial class PageAuthorize : Page
    {
        public PageAuthorize()
        {
            InitializeComponent();
            Classes.NavigationService.Initialize(MainFrame);
        }

        private DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");

            SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-OK4IG1R\\SQLEXPRESS;Trusted_Connection=Yes;DataBase=GIBDDDatabase;");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = TxtLogin.Text;
            string password = PsbPassword.Password;
            if (TxtLogin.Text.Length > 0)
            {
                if (PsbPassword.Password.Length > 0)
                {
                    DataTable dt_user = Select("SELECT * FROM [dbo].[Authorization] WHERE [login] = '" + login + "' AND [password] = '" + password + "'");
                    if (dt_user.Rows.Count > 0)
                    {
                        MessageBox.Show("Пользователь авторизовался");
                        ClassFrame.frmObj.Navigate(new PageNavigate());
                    }
                    else MessageBox.Show("Пользователя не найден");
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Введите логин");
        }
    }
}
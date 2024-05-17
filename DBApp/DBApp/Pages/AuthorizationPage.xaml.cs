using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DBApp.Classes;
using DBApp.DBModel;
using DBApp.Pages;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtLogin.Text) || string.IsNullOrEmpty(PsPassword.Password))
                {
                    MessageBox.Show("Пожалуйста, заполните логин и пароль!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var a = ConnectionClass.connect.Login_Password_Stud.Where(d => d.Login == TxtLogin.Text && d.Pasword == PsPassword.Password).FirstOrDefault();
                    if (a != null)
                    {
                        var z = a.Students.FirstOrDefault();
                        if (a.ID_Log_Pass_Stud == a.ID_Log_Pass_Stud)
                        {
                            MessageBox.Show($"Добро пожаловать {z.Suname} {z.Name} {z.Patronumic}", "Авторизация прошла успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new StudentsPage());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль неверный!!!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}

using CenterSwimming.Components;
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

namespace CenterSwimming.Pages
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

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Регистрация", new RegistrationPage()));

        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            App.AuthUser = App.db.User.FirstOrDefault(x=> x.Login == LoginTb.Text && x.Password == PasswordPb.Password);
            if(App.AuthUser != null) 
            {
                
                Navigation.NextPage(new PageComponent("Срисок услуг", new ServiceListPage()));

            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
                

        }
    }
}

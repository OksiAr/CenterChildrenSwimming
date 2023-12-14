using CenterSwimming.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Regex regexPhone = new Regex(@"^(\+7|8)\d{10}$");
                Regex emailRegex = new Regex(@"^\S+@(mail\.ru|gmail\.com|yndex\.ru)$");
                if (emailRegex.IsMatch(EmailTb.Text))
                {
                    if (regexPhone.IsMatch(PhoneTb.Text))
                    {
                        var user = App.db.User.Add(new User()
                        {
                            Login = LoginTb.Text,
                            Password = PasswordTb.Text,
                            RoleId = 1
                        });
                        App.db.Client.Add(new Client()
                        {
                            FirstName = FirstNameTb.Text,
                            LastName = LastNameTb.Text,
                            Patronymic = PatronymicTb.Text,
                            Email = EmailTb.Text,
                            Phone = PhoneTb.Text
                        });
                        App.db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Неверная почта!");
                    }

                }
                else
                {
                    MessageBox.Show("Неверный номер телефона!");
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }


        }
    }
}

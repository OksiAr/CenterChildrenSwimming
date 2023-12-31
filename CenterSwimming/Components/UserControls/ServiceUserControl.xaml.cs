﻿using CenterSwimming.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CenterSwimming.Components.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ServiceUserControl.xaml
    /// </summary>
    public partial class ServiceUserControl : UserControl
    {

        private Service service;
        public ServiceUserControl(Service _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = _service;
            if (App.AuthUser.RoleId == 1)
            {
                EditBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                ByeBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Редактирование услуги", new AddEditServicePage(service)));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show($"Вы действительно хотите удалить запись {service.Title}?", "Удаление", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (service.ClientService.Count != 0)
                {
                    MessageBox.Show("Удаление запрещено");
                }
                else
                {
                    App.db.Service.Remove(service);
                    App.db.SaveChanges();
                    App.serviceListPage.Refresh();
                }
            }

        }

        private void ByeBtn_Click(object sender, RoutedEventArgs e)
        {
           
            Navigation.NextPage(new PageComponent("Покупка абонемента", new ByePage(service)));

        }
    }
}

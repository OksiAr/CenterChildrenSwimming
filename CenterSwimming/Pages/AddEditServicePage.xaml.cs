using CenterSwimming.Components;
using CenterSwimming.Components.UserControls;
using Microsoft.Win32;
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

namespace CenterSwimming.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        Service service;
        public AddEditServicePage(Service _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = service;
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg*|*.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                App.db.ServicePhoto.Add(new ServicePhoto
                {
                    ServiceID = service.ID,
                    PhotoByte = File.ReadAllBytes(openFile.FileName)

                });
                App.db.SaveChanges();
                RefreshPhoto();

            }

        }
        public void RefreshPhoto()
        {
            PhotoWp.Children.Clear();
            foreach (var photo in service.ServicePhoto)
            {
                PhotoWp.Children.Add(new PhotoUserControl(photo));
            }
            BitmapImage bitmapImage = new BitmapImage();
            MemoryStream byteStream = new MemoryStream(service.MainImage);
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = byteStream;
            bitmapImage.EndInit();
            MainImage.Source = bitmapImage;
        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            try
            {
                if (service.ID == 0)
                {
                    if (App.db.Service.Any(x => x.Title == service.Title))
                    {
                        errors.AppendLine("Такая услуга уже существует!");
                    }
                    else
                    {
                        App.db.Service.Add(service);
                    }
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                }
                else
                {
                    App.db.SaveChanges();
                    MessageBox.Show("Сохранено!");
                    
                   Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
                    App.serviceListPage.Refresh();

                }

            }
            catch
            {
                errors.AppendLine("Заполните все поля!");
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                }
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(char.IsDigit(char.Parse(e.Text))))
            {
                e.Handled = true;
            }
        }

        private void EditImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg*|*.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                service.MainImage = File.ReadAllBytes(openFile.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }


        }
    }
}

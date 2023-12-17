using CenterSwimming.Components;
using CenterSwimming.Components.UserControls;
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
    /// Логика взаимодействия для ByePage.xaml
    /// </summary>
    public partial class ByePage : Page
    {
        Service service;
        public ByePage(Service _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = service;
            foreach (var trainer in App.db.Trainer)
            {
                trainerWp.Children.Add(new TrainerUserControl(trainer));
            }

        }
        private void ByeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(App.db.ClientService.FirstOrDefault(x=> x.ClientID == App.AuthClient.ID && x.ServiceID == 1) == null)
                {
                    MessageBoxResult result = MessageBox.Show($"Вы действительно хотите преобрести абонемент {service.Title} c тренером {App.SelectTrainer.FullName}", "Покупка абонемента", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        App.db.ClientService.Add(new ClientService()
                        {
                            ClientID = App.AuthClient.ID,
                            ServiceID = service.ID,
                            Count = 0,
                            TrainerId = App.SelectTrainer.Id,
                            IsComplited = false
                        }); 
                        App.db.SaveChanges();

                    }
                
                }
                else
                {
                    MessageBox.Show("Абонемент на первое посещение был уже использован ранее!");
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }

        }
    }
}

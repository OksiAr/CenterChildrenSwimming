using CenterSwimming.Components;
using CenterSwimming.Components.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace CenterSwimming.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientRecordPage.xaml
    /// </summary> 

    public partial class ClientRecordPage : Page
    {
        private static ClientService clientService = App.db.ClientService.FirstOrDefault(x => x.ClientID == App.AuthClient.ID && x.IsComplited != true);
        public ClientRecordPage()
        {
            InitializeComponent();
            DateC.DisplayDateStart = DateTime.Now;
            RefreshDate();
            ListRefresh();
            if (clientService.ClientServiceDate.All(x => x.DateOfLesson < DateTime.Now) && clientService.ClientServiceDate.Count == clientService.Service.Count)
            {
                clientService.IsComplited = true;
                App.db.SaveChanges();
            }

        }
        private void ListRefresh()
        {
            CountLessonTb.Text = $"У вас использовано {clientService.Count} из {clientService.Service.Count} занятий";
            ClientServiceDateList.ItemsSource = App.db.ClientServiceDate.OrderBy(x => x.DateOfLesson).Where(x => x.ClientService.ClientID == App.AuthClient.ID && x.DateOfLesson > DateTime.Now).ToList();
        }
        private void RefreshDate()
        {
            List<string> timesList = new List<string>();
            timesList.Clear();
            //TimeWp.Children.Clear();
            if (DateTime.Now < DateC.SelectedDate)
            {

                for (int time = 8; time <= 20; time++)
                {
                    timesList.Add(time + ":00");
                    //TimeWp.Children.Add(new TimeUserControl(time + ":00"));
                }
                TimeList.ItemsSource = timesList;
            }
            else
            {
                for (int time = 8; time <= 20; time++)
                {
                    if (time > DateTime.Now.Hour)
                    {
                        timesList.Add(time + ":00");
                        //TimeWp.Children.Add(new TimeUserControl(time + ":00"));
                    }
                }
                TimeList.ItemsSource = timesList;
            }
        }

        private void DateC_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {

        }
        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (clientService.Count != clientService.Service.Count)
                {
                    if (TimeList.SelectedItem != null)
                    {
                        var date = $"{DateC.SelectedDate.Value.Date.ToString("dd.MM.yyyy")} {TimeList.SelectedItem}";
                        App.db.ClientServiceDate.Add(new ClientServiceDate()
                        {
                            DateOfLesson = DateTime.Parse(date),
                            ClientServiceId = clientService.ID,
                        });
                        clientService.Count++;
                        App.db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Укажите время из списка!");
                    }
                }
                else
                {
                    MessageBox.Show("Использованы все занятия абонемента!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так!" + ex.Message);
            }
            ListRefresh();
        }


        private void DateC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RefreshDate();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var selRow = (sender as Button).DataContext as ClientServiceDate;
            MessageBoxResult result = MessageBox.Show($"Вы действительно хотите отменить запись на {selRow.DateOfLesson.ToString("dd.MM.yyyy")}", "Отмена записи", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                App.db.ClientServiceDate.Remove(selRow);
                clientService.Count--;
                App.db.SaveChanges();
                ListRefresh();
            }

        }
    }
}




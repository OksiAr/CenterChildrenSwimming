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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace CenterSwimming.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientRecordPage.xaml
    /// </summary>
    public partial class ClientRecordPage : Page
    {
        public ClientRecordPage()
        {
            InitializeComponent();
            DateC.DisplayDateStart = DateTime.Now;
            RefreshDate();
            ListRefresh();

        }
        private void ListRefresh()
        {
            CountLessonTb.Text = $"У вас использовано {App.db.ClientService.FirstOrDefault(x=> x.ClientID == App.AuthClient.ID).Count} из {App.db.ClientService.FirstOrDefault(x=> x.ClientID == App.AuthClient.ID).Service.Count} занятий";
            ClientServiceDateList.ItemsSource = App.db.ClientServiceDate.Where(x=> x.ClientService.ClientID == App.AuthClient.ID).ToList(); 
        }
        private void RefreshDate()
        {
            TimeWp.Children.Clear();
            if (DateTime.Now < DateC.SelectedDate)
            {

                for (int time = 8; time <= 20; time++)
                {
                    TimeWp.Children.Add(new TimeUserControl(time + ":00"));
                }
            }
            else
            {
                for (int time = 8; time <= 20; time++)
                {
                    if (time > DateTime.Now.Hour)
                    {
                        TimeWp.Children.Add(new TimeUserControl(time + ":00"));
                    }
                }
            }
        }

        private void DateC_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {

        }
        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.db.ClientServiceDate.Add(new ClientServiceDate()
                {
                    DateOfLesson = DateC.SelectedDate.Value,
                    ClientServiceId = App.db.ClientService.FirstOrDefault(x => x.ClientID == App.AuthClient.ID).ID,
                });
                App.db.ClientService.FirstOrDefault(x => x.ClientID == App.AuthClient.ID).Count++;
                App.db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
            ListRefresh();

        }

        private void DateC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RefreshDate();
        }

        
    }
}




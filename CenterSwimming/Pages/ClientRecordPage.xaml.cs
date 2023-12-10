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
    /// Логика взаимодействия для ClientRecordPage.xaml
    /// </summary>
    public partial class ClientRecordPage : Page
    {
        public ClientRecordPage()
        {
            InitializeComponent();
            for(int time = 8; time<=20; time++)
            {
                if (time > DateTime.Now.Hour) 
                {
                    TimeWp.Children.Add(new TimeUserControl(time + ":00"));
                }          
            }            
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

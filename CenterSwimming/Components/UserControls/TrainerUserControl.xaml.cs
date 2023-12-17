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

namespace CenterSwimming.Components.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TrainerUserControl.xaml
    /// </summary>
    public partial class TrainerUserControl : UserControl
    {

        Trainer trainer;
        public TrainerUserControl(Trainer _trainer)
        {
            InitializeComponent();
            trainer= _trainer;
            this.DataContext = trainer;
        }

   

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            App.SelectTrainer = trainer;
        }
    }
}

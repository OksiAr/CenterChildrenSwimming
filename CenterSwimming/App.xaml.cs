using CenterSwimming.Components;
using CenterSwimming.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CenterSwimming
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CenterSwimmingDbEnt db = new CenterSwimmingDbEnt();
        public static User AuthUser;
        public static Client AuthClient;
        public static AddEditServicePage servicePage;
        public static ServiceListPage serviceListPage;
        public static Trainer SelectTrainer;
    }
}

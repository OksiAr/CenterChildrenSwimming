﻿using CenterSwimming.Components;
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
        public static CenterSwimmingDbEntities db = new CenterSwimmingDbEntities();
        public static User AuthUser;
        public static AddEditServicePage servicePage;
        public static ServiceListPage serviceListPage;
    }
}
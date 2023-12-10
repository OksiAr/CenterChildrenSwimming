﻿using System;
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
    /// Логика взаимодействия для TimeUserControl.xaml
    /// </summary>
    public partial class TimeUserControl : UserControl
    {
        public TimeUserControl(string time)
        {
            InitializeComponent();
            TimeBtn.Content = time;
        }
    }
}

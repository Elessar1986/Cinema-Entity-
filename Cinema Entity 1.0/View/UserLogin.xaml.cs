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
using System.Windows.Shapes;
using Cinema_Entity_1._0.ViewModel;

namespace Cinema_Entity_1._0.View
{
    /// <summary>
    /// Логика взаимодействия для UserLogin.xaml
    /// </summary>
    public partial class UserLogin 
    {
        public UserLogin()
        {
            InitializeComponent();
            DataContext = new UserLoginViewModel();
        }
    }
}

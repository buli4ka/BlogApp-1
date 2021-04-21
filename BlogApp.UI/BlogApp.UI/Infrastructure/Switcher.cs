﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BlogApp.UI.Infrastructure
{
    static class Switcher
    {
        public static INavigate ContentArea { get; set; }
        public static void Switch(UserControl page)
        {
            ContentArea.Navigate(page);
        }
    }
}

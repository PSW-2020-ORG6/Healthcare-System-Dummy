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

namespace klinika_zdravo.Pages
{
    /// <summary>
    /// Interaction logic for BlogStranica.xaml
    /// </summary>
    public partial class BlogStranica : Page
    {
        public BlogStranica()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dialog1.IsOpen = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dialog1.IsOpen = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dialog1.IsOpen = true;
        }
    }
}

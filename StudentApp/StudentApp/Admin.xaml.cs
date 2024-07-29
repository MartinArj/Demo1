using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentApp
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            Action.Navigate(new temp());
        }

        private void AddSection_Click_1(object sender, RoutedEventArgs e)
        {
            Action.Navigate(new AddSection());
        }

        private void AddStudent_Click_1(object sender, RoutedEventArgs e)
        {
            Action.Navigate(new AddStudent());
        }

        private void AddStaff_Click_1(object sender, RoutedEventArgs e)
        {
            Action.Navigate(new AddStaff());
        }

        private void AddExamType_Click_1(object sender, RoutedEventArgs e)
        {
            Action.Navigate(new AddExamType());
        }

        private void TeacherAllocation_Click_1(object sender, RoutedEventArgs e)
        {
            Action.Navigate(new TeacherAllocation());
        }

        private void AddSubject_Click_1(object sender, RoutedEventArgs e)
        {
            Action.Navigate(new AddSubject());
        }
    }
}

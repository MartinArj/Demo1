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
    /// Interaction logic for AdddStaff.xaml
    /// </summary>
    public partial class AdddStaff : Page
    {
        public AdddStaff()
        {
            InitializeComponent();
        }
        private void address_Click_1(object sender, RoutedEventArgs e)
        {
            address_pannel.Visibility = Visibility.Visible;
            AddStaffDetail_pannel.Visibility = Visibility.Collapsed;
            string name = sname.Text;
            string joining_year = joiningYear.Text;
            string previous_Experious = previousExperence.Text;
            string dobl = dob.Text;
            string quallification = Qualification.Text;
            staff = new staffDetails(name, quallification, joining_year, previous_Experious);
            Repositories.InsertStaffDetails(staff); 

        }

        private void Phone_number_Click_1(object sender, RoutedEventArgs e)
        {
            address_pannel.Visibility = Visibility.Collapsed;
            mobile_number_pannel.Visibility = Visibility.Visible;

        }
        staffDetails staff;
        private void staff_detail_Click_1(object sender, RoutedEventArgs e)
        {
            AddStaffDetail_pannel.Visibility = Visibility.Visible;
            address_pannel.Visibility = Visibility.Collapsed;
          
        }

        private void privious_address_Click_1(object sender, RoutedEventArgs e)
        {
            address_pannel.Visibility = Visibility.Visible;
            mobile_number_pannel.Visibility = Visibility.Collapsed;
        }

        private void NewMobileNumber_Click_1(object sender, RoutedEventArgs e)
        {
           

        }

        private void complete_Click_1(object sender, RoutedEventArgs e)
        {
           

        }
    }
}

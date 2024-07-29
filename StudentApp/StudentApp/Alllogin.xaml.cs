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
    /// Interaction logic for Alllogin.xaml
    /// </summary>
    public partial class Alllogin : Page
    {
       
        public List<staffDetails> staff { get; set; }
        public Alllogin()
        {
            InitializeComponent();
            staff = Repositories.GetAllStaffDetails();
          

        }

        private void login_btn_Click_1(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;
            string password = PasswordBox.Text;
            if (name == "martin" && password == "12345")
            {
                this.NavigationService.Navigate(new Admin());
            }
            if (IsStaffAvailable(name, password))
            {
                staffDetails tempStaff = GetMatchingStaff(name, password);
                this.NavigationService.Navigate(new TeacherOptions(tempStaff));

            }
            else
            {
                MessageBox.Show("***wrong***");
            }


        }
        private bool IsStaffAvailable(string name, string dob)
        {
            foreach (var Staff in staff)
            {
                if (Staff.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && Staff.Dob.Equals(dob))
                {
                    return true;
                }
            }
            return false;
        }

        // Method to return the matching staff member object
        private staffDetails GetMatchingStaff(string name, string dob)
        {
            foreach (var Staff in staff)
            {
                if (Staff.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && Staff.Dob.Equals(dob))
                {
                    return Staff;
                }
            }
            return null;
        }
    }
}

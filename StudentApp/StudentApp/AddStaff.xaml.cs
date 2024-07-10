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
        // after enter detail
        private void address_Click_1(object sender, RoutedEventArgs e)
        {
            address_pannel.Visibility = Visibility.Visible;
            AddStaffDetail_pannel.Visibility = Visibility.Collapsed;
            string name = sname.Text;
            string joining_year = joiningYear.Text;
            string previous_Experious = previousExperence.Text;
            string Dob = dob.Text;
            string quallification = Qualification.Text;
            staff = new staffDetails(name,Dob, quallification, joining_year, previous_Experious);
          

        }
        //after enter address it will excute..
        int id = -1;
        StaffAddress saffad;
        private void Phone_number_Click_1(object sender, RoutedEventArgs e)
        {
            address_pannel.Visibility = Visibility.Collapsed;
            mobile_number_pannel.Visibility = Visibility.Visible;
             id = Repositories.GetStaffId(staff);
            string door = door_no.Text;
            string street = Street.Text;
            string village = Village.Text;
            string city = City.Text;
            string state = State.Text;
            string pincode = Pincode.Text;
            string mailid = Mailid.Text;
             saffad = new StaffAddress(id,door, street, village, city, state, pincode, mailid);
         
            
        }
     private  staffDetails staff;
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



        //add new mobile number
        staffMobileNumber num;
        private void NewMobileNumber_Click_1(object sender, RoutedEventArgs e)
        {
            string mobile_number = mobile_no.Text;
            string mob_type = select;
            num = new staffMobileNumber(id, mobile_number, mob_type);
            Repositories.InsertStaffMobile(num);
            mobile_no.Clear();

        }

        private void complete_Click_1(object sender, RoutedEventArgs e)
        {   //to database staffdetail
            Repositories.InsertStaffDetails(staff);

            //to database staffdetail
            Repositories.InsertStaffAdress(saffad);
            string mobile_number = mobile_no.Text;
            string mob_type = select;
            num = new staffMobileNumber(id, mobile_number, mob_type);
            Repositories.InsertStaffMobile(num);
            mobile_no.Clear();
        }
      private  string select;
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            select = r.Content.ToString();
        }
    }
}

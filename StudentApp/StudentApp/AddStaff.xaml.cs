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
    public partial class AddStaff : Page
    {
        public AddStaff()
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
            int upto = int.Parse(uptoclass.Text.ToString());
            string sub = subject.Text;
            string gender = MaleRadioButton.IsChecked == true ? "Male" : "Female";
            bool isactive=true;
            staff = new staffDetails(name,Dob, quallification,joining_year,previous_Experious,gender,sub,upto,isactive);
          

        }
        //after enter address it will excute..
        int id = -1;
        StaffAddress staffad;
        private void Phone_number_Click_1(object sender, RoutedEventArgs e)
        {
            address_pannel.Visibility = Visibility.Collapsed;
            mobile_number_pannel.Visibility = Visibility.Visible;
            
            string door = door_no.Text;
            string street = Street.Text;
            string village = Village.Text;
            string city = City.Text;
            string state = State.Text;
            string pincode = Pincode.Text;
            string mailid = Mailid.Text;
             staffad = new StaffAddress(id,door, street, village, city, state, pincode, mailid,AdType);
             staff.AddressList.Add(staffad);
            
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
            staff.mobilenumbers.Add(num);
   
            mobile_no.Clear();

        }

        private void complete_Click_1(object sender, RoutedEventArgs e)
        {   //to database staffdetail
           
            string mobile_number = mobile_no.Text;
            string mob_type = select;
            num = new staffMobileNumber(id, mobile_number, mob_type);
            staff.mobilenumbers.Add(num);
            Repositories.InsertStaffDetails(staff);
            id = Repositories.GetStaffId(staff);
            staff.Id = id;
            Repositories.InsertStaffAdress(staff);
            Repositories.InsertStaffMobile(staff);
            string s = "staff id " +id+ "name "+staff.Name+ "\ncompleted";
            MessageBox.Show(s);
            this.NavigationService.Navigate(new AddStaff());
      
        }
      private  string select;
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            select = r.Content.ToString();
        }

        private void Add_Address_Click_1(object sender, RoutedEventArgs e)
        {
            
            string door = door_no.Text;
            string street = Street.Text;
            string village = Village.Text;
            string city = City.Text;
            string state = State.Text;
            string pincode = Pincode.Text;
            string mailid = Mailid.Text;
            staffad = new StaffAddress(id, door, street, village, city, state, pincode, mailid,AdType);
            staff.AddressList.Add(staffad);

            door_no.Clear();
            Street.Clear();
             Village.Clear();
            City.Clear();
             State.Clear();
          Pincode.Clear();
          Mailid.Clear();
        
           check.Visibility = Visibility.Visible;
           if (0== staff.AddressList.IndexOf(staffad))
           {
               right.IsEnabled = false;
           }
           else
           {
               right.IsEnabled = true;
           }

        }
        byte AdType;
        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            string s = r.Content.ToString();
            if (s == "Permanent")
            {
                AdType = 1;
            }
            else
            {
                AdType = 0;
            }
        }

        private void left_Click_1(object sender, RoutedEventArgs e)
        {
            int intex = staff.AddressList.IndexOf(staffad);
            if (intex != 0)
            {
                staffad = staff.AddressList[intex - 1];
                SetAddress(staffad);
            }
            else
            {
                staffad = staff.AddressList[intex];
                SetAddress(staffad);
                right.IsEnabled = true;
                left.IsEnabled = false;
            }
        }

        private void right_Click_1(object sender, RoutedEventArgs e)
        {
            int intex = staff.AddressList.IndexOf(staffad);
            if (intex != staff.AddressList.Count - 2 && 1 < staff.AddressList.Count)
            {
                staffad = staff.AddressList[intex + 1];
                SetAddress(staffad);
            }
            else
            {
                if (staff.AddressList.Count == 1) { SetAddress(new StaffAddress()); }
                SetAddress(staffad);
                left.IsEnabled = true;
                right.IsEnabled = false;

            }

        }

        private void left1_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void right2_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void SetAddress(StaffAddress ad)
        {

            door_no.Text = ad.DoorNo;
            Street.Text = ad.Street;
            Village.Text = ad.Village;
            City.Text = ad.City;
            State.Text = ad.State;
            Pincode.Text = ad.Pin_Code;
            Mailid.Text = ad.Mail_Id;

        }
    }
}

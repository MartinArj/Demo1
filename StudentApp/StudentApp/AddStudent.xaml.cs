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
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Page
    {
        public Dictionary<int, List<char>> sec { get; set; }
        StudDetails student;
        public List <int> class_No{get;set;}
        public AddStudent()
        {
            InitializeComponent();
            
           
            sec = Repositories.GetClassSections();
            class_No = new List<int>(sec.Keys);
            studCls.ItemsSource = class_No;

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddStudent_panel.Visibility = Visibility.Visible;
            Stud_Address.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            insertstudentDetail();
          
            this.NavigationService.Navigate(new AddStudent());
           
        }

        //secont
        public void insertaddress(StudDetails temp)
        { 
           int StudId=Repositories.GetStudId(temp);
          
            string DoorNo=studDoorNo.Text;
            string Street=studStreet.Text;
            string Village=studVillage.Text;
            string City=studCity.Text;
            string State=studState.Text;
            string Pin_Code=studPinco.Text;
            string Mobile_Number=studmobileno.Text;
            string Mail_Id=studMail.Text;
            Address ad = new Address(StudId,DoorNo,Street,Village,City,State,Pin_Code,Mobile_Number,Mail_Id);
            Repositories.Insert_Address(ad);
        }

        public void insertstudentDetail()
        {
            string StudentName = studName.Text;
            string StudentSection = Sectionbox.SelectedItem.ToString();
            string StudentYear = studYear.Text;
            string StudentDOB = studDob.Text;
            string StudentBldGrp = studBldgrp.Text;
            int StudentClass = (int)studCls.SelectedItem;
            student = new StudDetails(StudentClass, StudentSection, StudentYear, StudentName, StudentDOB, StudentBldGrp);
            Repositories.InsertStudDetails(student);
            insertaddress(student);
        }

        private void add_stud_Click_1(object sender, RoutedEventArgs e)
        {

            AddStudent_panel.Visibility = Visibility.Collapsed;
            Stud_Address.Visibility = Visibility.Visible;
            
        }

        private void studCls_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (studCls.SelectedItem != null)
            {
                int selectedClass = int.Parse(studCls.SelectedItem.ToString());
                if (sec.ContainsKey(selectedClass))
                {
                    Sectionbox.ItemsSource = sec[selectedClass];
                }
            }
        }
    }
}

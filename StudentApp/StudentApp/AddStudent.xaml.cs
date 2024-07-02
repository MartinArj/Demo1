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
        StudDetails student;
        public List <int> class_No{get;set;}
        public AddStudent()
        {
            InitializeComponent();
            class_No = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            studCls.ItemsSource = class_No;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddStudent_panel.Visibility = Visibility.Visible;
            Stud_Address.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddStudent());
           
        }
        public void insertaddress()
        { 
           int StudId=0;
            int Class=int.Parse(studCls.Text);
            string Section=studSec.Text;
            string Year=studYear.Text;
            string DoorNo=studDoorNo.Text;
            string Street=studStreet.Text;
            string Village=studVillage.Text;
            string City=studCity.Text;
            string State=studState.Text;
            string Pin_Code=studPinco.Text;
            string Mobile_Number=studmobileno.Text;
            string Mail_Id=studMail.Text;
        }
        public void insertstudentDetail()
        {
            string StudentName = studName.Text;
            string StudentSection = studSec.Text;
            string StudentYear = studYear.Text;
            string StudentDOB 
                = studDob.Text;
            string StudentBldGrp = studBldgrp.Text;
            int StudentClass = (int)studCls.SelectedItem;
            student = new StudDetails(StudentClass, StudentSection, StudentYear, StudentName, StudentDOB, StudentBldGrp);
            Repositories.InsertStudDetails(student);
        }

        private void add_stud_Click_1(object sender, RoutedEventArgs e)
        {

            AddStudent_panel.Visibility = Visibility.Collapsed;
            Stud_Address.Visibility = Visibility.Visible;
            insertstudentDetail();
        }
    }
}

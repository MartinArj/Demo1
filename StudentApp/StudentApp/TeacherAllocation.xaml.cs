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
    /// Interaction logic for TeacherAllocation.xaml
    /// </summary>
    public partial class TeacherAllocation : Page
    {
        public Dictionary<int, List<char>> sec { get; set; }
        public Dictionary<int, List<string>> subjectDetailsDict { get; set; }
        public TeacherAllocation()
        {
            InitializeComponent();
            subjectDetailsDict = new Dictionary<int, List<string>>();
            subjectDetailsDict = Repositories.GetSubjectDetails();
            sec = new Dictionary<int, List<char>>();
            load_section();
            ClassBox.ItemsSource = new List<int>(sec.Keys);
        }
        private void load_section()
        {
            List<ClassDetails> temp = Repositories.GetAllClassDetails();
            foreach (var item in temp)
            {


                if (!sec.ContainsKey(item.Class))
                {
                    sec[item.Class] = new List<char>();
                }

                sec[item.Class].Add(item.Section[0]);


            }

        }

        private void ClassBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ClassBox.SelectedItem != null)
            {
                SubjectBox.ItemsSource = subjectDetailsDict[int.Parse(ClassBox.SelectedItem.ToString())];
                SectionBox.ItemsSource = sec[int.Parse(ClassBox.SelectedItem.ToString())];
            }
        }

        private void SubjectBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (SubjectBox.SelectedItem != null)
            {
                var sub = Repositories.GetStaffBySubject(SubjectBox.SelectedItem.ToString()).Select(s => s.Name) // Select the Name property
             .Distinct() // Remove duplicates if any
             .OrderBy(name => name) // Optional: sort alphabetically
             .ToList();
               StaffBox.ItemsSource = sub;
            }
        }

        private void add_staff_sub_Click_1(object sender, RoutedEventArgs e)
        {
            if (SubjectBox.SelectedItem != null && ClassBox.SelectedItem != null && SectionBox.SelectedItem != null && StaffBox.SelectedItem != null)
            {   
                int Class=(int)ClassBox.SelectedItem;
                string sec=SectionBox.SelectedItem.ToString();
                string sub=SubjectBox.SelectedItem.ToString();
                int subid = Repositories.GetSubjectId(Class, sub);
                string staff=(string)StaffBox.SelectedItem;
                bool isChecked = myCheckBox.IsChecked ?? false;
               int staffid= Repositories.GetStaffIdByName(staff);
               SubAndStaffRelation s = new SubAndStaffRelation(subid, Class, sec,DateTime.Now.Year.ToString(), staffid, isChecked);
               Repositories.InsertSubAndStaffRelation(s);
               this.NavigationService.Navigate(new TeacherAllocation());
            }

        }
    }
}

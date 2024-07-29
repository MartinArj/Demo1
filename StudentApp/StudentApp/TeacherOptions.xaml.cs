using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StudentApp
{
    /// <summary>
    /// Interaction logic for TeacherOptions.xaml
    /// </summary>
    public partial class TeacherOptions : Page
    {
        public List<ClassDetails> listclass { get; set; }
      
        public staffDetails staff;
        public ObservableCollection<ExamType> ExamTypeList { get; set; }
        public ObservableCollection<StudDetails> stud { get; set; }
        private List<StudentsMarks> studmark;
        int Staffid;
        public staffDetails t;
        public TeacherOptions(staffDetails t)
        {
            this.t = t;
            InitializeComponent();
            Staffid = Repositories.GetStaffId(t);
            listclass = Repositories.GetClassDetailsForStaff(Staffid);
            this.DataContext = this;
        }

        int selectedClass;
        string selectedSection;

        private void changed_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            Exam_type_combobox.IsEnabled = true; ;
            if (classlist.SelectedItem != null)
            {
                var selectedClassDetails = classlist.SelectedItem as ClassDetails;
                if (selectedClassDetails != null)
                {
                   
                    selectedClass = selectedClassDetails.Class;
                    selectedSection = selectedClassDetails.Section;
                    ExamTypeList = Repositories.GetExamTypesByClass(selectedClass);
                    examTypeComboBox.ItemsSource = ExamTypeList;
                   
                   
                }
            }
        }

        private void submit_Click_1(object sender, RoutedEventArgs e)
        {
            var a = examTypeComboBox.SelectedItem as ExamType;
          
                  
           
          
            foreach (var m in studmark)
            {
                Repositories.InsertStudentMarks(m);
            }
    

            // Save studmark to the database or process it as needed



            stud.Clear();
            datagrid.ItemsSource = null;
        }

        private void examTypeComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Exam_type_combobox.IsEnabled = false;
            mark_enty_section.IsEnabled = true;
            //init_load();
            studmark = GetStudentMarksWithDetails();
            datagrid.ItemsSource = studmark;
        }
        public List<StudentsMarks> GetStudentMarksWithDetails()
        {
            var a = examTypeComboBox.SelectedItem as ExamType;
            ObservableCollection<StudDetails> studentDetailsList = Repositories.GetStudentsByClassSection(selectedClass, selectedSection);
            List<StudentsMarks> existingMarksList = Repositories.GetStudentMarksByCriteria(selectedClass, selectedSection, DateTime.Now.Year.ToString(), t.SubjectsTaught, a.Exam_Type);
            List<StudentsMarks> finalMarksList = new List<StudentsMarks>();
           
            foreach (var student in studentDetailsList)
            {
                var existingMarks = existingMarksList
                    .Where(m => m.StudId == student.Studid && m.Class == student.Class && m.Section == student.Section && m.Year == student.Year) .ToList();

                // If marks are already present, use them; otherwise, create a new entry with default values
                if (existingMarks.Count > 0)
                {
                    finalMarksList.AddRange(existingMarks);
                }
                else
                {
                    // If no marks exist for this student, add a default entry
                    // You might need to adjust the following to fit your requirements
                    finalMarksList.Add(new StudentsMarks(student.Studid, student.Class, student.Section, student.Year,t.SubjectsTaught,a.Exam_Type, student.Name, 0));
                }
            }

            return finalMarksList;
        }
        private void init_load()
        {  var a = examTypeComboBox.SelectedItem as ExamType;
            // Ensure examTypeComboBox.SelectedItem is not null
        studmark = Repositories.GetStudentMarksByCriteria(selectedClass, selectedSection, DateTime.Now.Year.ToString(), t.SubjectsTaught, a.Exam_Type);
           
            if (a == null)
            {
                MessageBox.Show("Please select an exam type.");
              
            }

            // Ensure stud is not null
            if (stud == null)
            {
                MessageBox.Show("Student list is not initialized.");
           
            }

            // Initialize studmark if it's not already initialized
            if (studmark == null)
            {
                studmark = new List<StudentsMarks>();
            }

            foreach (var item in stud)
            {
                

               
                int _id = item.Studid;
                int _Class = item.Class;
                 string _s=item.Section;
                 string _year = item.Year;
                 string _Sub = t.SubjectsTaught;
                 string _TypeOfExam = a.Exam_Type;
                string _Name=item.Name;
               

                studmark.Add(new StudentsMarks
                {
                    StudId = _id,
                    Class = _Class,
                    Section = _s,
                    Year = _year,
                    Subject = _Sub,            // Ensure this is the correct value
                    TypeOfExam = _TypeOfExam,              // Ensure this is the correct value
                    Name = _Name,
                    Mark = 0
                });
            }
        }


       
    }
}

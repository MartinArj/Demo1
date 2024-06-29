using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TeacherOptions.xaml
    /// </summary>
    public partial class TeacherOptions : Page
    {
        public List<string> listclass { get; set; }

        public List<string> ExamTypeList { get; set; }
        public ObservableCollection<stud> marklist;

        public TeacherOptions()
        {
            InitializeComponent();
            DataContext = this;
            listclass = new List<string>() { "1 A", "2 C", "3 A", "4 B", "5 C"};
            ExamTypeList = new List<string>() { "mid","end","final"};
        }

        private void changed_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Exam_type_combobox.IsEnabled = true;

        }

        private void ExamType_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            marklist = new ObservableCollection<stud>();
            marklist.Add(new stud("1", "martin"));
            marklist.Add(new stud("1", "martin"));
            marklist.Add(new stud("1", "martin"));
            marklist.Add(new stud("1", "martin"));
            marklist.Add(new stud("1", "martin"));
            marklist.Add(new stud("1", "martin"));
            datagrid.ItemsSource = marklist;
            Exam_type_combobox.IsEnabled = false;
            mark_enty_section.IsEnabled = true;
        }

        private void submit_Click_1(object sender, RoutedEventArgs e)
        {
            datagrid = new DataGrid();
            mark_enty_section.IsEnabled = false;
            Exam_type_combobox.IsEnabled = false;
            marklist.Clear();
        }
    }
    public class stud {
        private string _Id;

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Mark;

        public string Mark
        {
            get { return _Mark; }
            set { _Mark = value; }
        }
        public stud(string id, string name)
        { 
          this._Id=id;
          this._Name=name;
          this.Mark = "";

        }
    }
}

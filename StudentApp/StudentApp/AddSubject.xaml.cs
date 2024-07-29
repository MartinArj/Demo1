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
    /// Interaction logic for AddSubject.xaml
    /// </summary>
    public partial class AddSubject : Page
    {
        public Dictionary<int, List<string>> subjectDetailsDict { get; set; }
        public List<int> class_no { get; set; }
        public AddSubject()
        {
            InitializeComponent();
            class_no = Repositories.GetAllClasses();
            ClassBox.ItemsSource = class_no;
            subjectDetailsDict = new Dictionary<int, List<string>>();
            subjectDetailsDict = Repositories.GetSubjectDetails();
      
        }

        private void AddSubject_Click_1(object sender, RoutedEventArgs e)
        {
            int Class =int.Parse( ClassBox.SelectedItem.ToString());
            string Subject = subject.Text;
            SubjectDetails sub = new SubjectDetails(Class,Subject);
            Repositories.InsertSubjectDetails(sub);
            if (!subjectDetailsDict.ContainsKey(Class))
            {
                subjectDetailsDict[Class] = new List<string>();
            }

            subjectDetailsDict[Class].Add(Subject);
            ClassBox.SelectedItem=null;

        }

        private void Update_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Remove_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ClassBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ClassBox.SelectedItem != null)
            {
                int Class = int.Parse(ClassBox.SelectedItem.ToString());
                if (subjectDetailsDict.ContainsKey(Class))
                    class_subjects.ItemsSource = subjectDetailsDict[Class];
                else
                    class_subjects.ItemsSource = null;
            }
        }

        private void class_subjects_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (class_subjects.SelectedItem != null)
            {
                subject.Text = class_subjects.SelectedItem.ToString();
            }
        }
    }
}

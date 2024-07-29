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
    /// Interaction logic for AddExamType.xaml
    /// </summary>
    public partial class AddExamType : Page
    {
        public AddExamType()
        {
            InitializeComponent();
            ClassBox.ItemsSource = Repositories.GetAllClasses();
        }

        private void ClassBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void InsertButton_Click_1(object sender, RoutedEventArgs e)
        {
            int Class = 0; ;
        if (ClassBox.SelectedItem != null)
        {
            Class = int.Parse(ClassBox.SelectedItem.ToString());
        }
        string ExamType = Examtype.Text;
        float mark=0;
        if(MaxMark.Text!=null)
            mark = float.Parse(ClassBox.SelectedItem.ToString());
        ExamType type = new ExamType(ExamType,Class,mark);
        Repositories.InsertExamType(type);
        this.NavigationService.Navigate(new AddExamType());

        }
    }
}

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
using System.Windows.Shapes;

namespace StudentApp
{
    /// <summary>
    /// Interaction logic for StudentSubject.xaml
    /// </summary>
    public partial class StudentSubject : Window
    {
        public List<int> class_no { get; set; }
        public StudentSubject()
        {
            InitializeComponent();
            class_no = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            clas.ItemsSource = class_no;
        }
    }
}

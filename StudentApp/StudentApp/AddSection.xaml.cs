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
    /// Interaction logic for AddSection.xaml
    /// </summary>
    public partial class AddSection : Page
    {
        public Dictionary<int, List<char>> sec { get; set; }
        private List<int> classlist = Repositories.GetAllClasses();
        public AddSection()
        {
            sec = new Dictionary<int, List<char>>();
            InitializeComponent();
             load_section();
            ClassItem.ItemsSource = classlist;
           
            this.DataContext = this;
        }
      
        private void Remove_Click_1(object sender, RoutedEventArgs e)
        {

        }
        string s;
        int c;
        private void Add_Click_1(object sender, RoutedEventArgs e)
        {
           s= Section.Text;
           c=int.Parse(ClassItem.SelectedItem.ToString());
           ClassDetails section=new ClassDetails(c,s);
           Repositories.InsertClassDetails(section);
           if (!sec.ContainsKey(c))
           {
               sec[c] = new List<char>();
           }

           sec[c].Add(s[0]);
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

        private void ClassItem_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ClassItem.SelectedItem != null)
            {
                int selectedClass = (int)ClassItem.SelectedItem;
                if (sec.ContainsKey(selectedClass))
                    classsections.ItemsSource = sec[selectedClass];
                else
                    classsections.ItemsSource = null;

            }

        }
    }
}


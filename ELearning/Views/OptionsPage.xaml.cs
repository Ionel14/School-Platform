using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ELearning.Views
{
    /// <summary>
    /// Interaction logic for OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Window
    {
        public OptionsPage()
        {
            InitializeComponent();
            contentFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new PersonsManagement());
        }

        private void GoToClasses(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new ClassesManagement());
        }

        private void GoToCourses(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new CoursesManagement());
        }

        private void GoToStudents(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new StudentsToClass());
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vulcanean Ionel\n10LF213");
        }
    }
}

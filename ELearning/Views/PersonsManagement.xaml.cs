using ELearning.ViewModels;
using System.Windows.Controls;


namespace ELearning.Views
{
    /// <summary>
    /// Interaction logic for PersonsManagement.xaml
    /// </summary>
    public partial class PersonsManagement : UserControl
    {
        public PersonsManagement()
        {
            DataContext = new PersonsPageVM();
            InitializeComponent();
        }
    }
}

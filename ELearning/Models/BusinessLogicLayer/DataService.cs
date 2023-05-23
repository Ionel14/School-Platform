using ELearning.Models.Data;
using ELearning.Models.Entities;
using System.Windows;

namespace ELearning.Models.BusinessLogicLayer
{
    static internal class DataService
    {
        static public readonly SchoolDbContext context = new SchoolDbContext();
        static public Person user { get; set; }

        static private Window currentWindow;
        static public Window CurrentWindow {
            get {
                return currentWindow;
            } 
            
            set {
                if (currentWindow != null)
                {
                    currentWindow.Close();
                }
                currentWindow = value;
                currentWindow.Show();
            } 
        }

        static public PersonBLL personBLL { get; set; } = new PersonBLL();
    }
}

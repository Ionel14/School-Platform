using ELearning.Models.BusinessLogicLayer;
using ELearning.Models.BusinessLogicLayer.Dtos;
using ELearning.Models.Entities;
using ELearning.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaEF.Helpers;

namespace ELearning.ViewModels
{
    internal class StudentsToClassVM : BaseVM
    {
        private ClassesBLL classesBLL = new ClassesBLL();
        private StudentsBLL studentsBLL;

        public StudentsToClassVM()
        {
            studentsBLL = new StudentsBLL(classesBLL);
        }

        public ObservableCollection<Person> Students
        {
            get => new ObservableCollection<Person>(DataService.personBLL.PersonsList.Where((person) => person.RoleId == (int)UserRole.Student));
            set
            {
                NotifyPropertyChanged("Students");
            }
        }

        public ObservableCollection<Class> Classes
        {
            get
            {
                return classesBLL.ClassesList;
            }

            set
            {
                classesBLL.ClassesList = value;
                NotifyPropertyChanged("Classes");
            }
        }

        private Class selectedClass;
        public Class SelectedClass
        {
            get
            {
                return selectedClass;
            }
            set
            {
                selectedClass = value;
                NotifyPropertyChanged("SelectedClass");
            }
        }

        private ICommand addStudentCommand;
        public ICommand AddStudentCommand
        {
            get
            {
                if (addStudentCommand == null)
                {
                    addStudentCommand = new RelayCommand<StudentDto>(studentsBLL.AddStudent);
                }
                return addStudentCommand;
            }
            set
            {
                addStudentCommand = value;
            }
        }

        private ICommand deleteStudentCommand;
        public ICommand DeleteStudentCommand
        {
            get
            {
                if (deleteStudentCommand == null)
                {
                    deleteStudentCommand = new RelayCommand<StudentDto>(studentsBLL.DeleteStudentFromClass);
                }
                return deleteStudentCommand;
            }
            set
            {
                deleteStudentCommand = value;
            }
        }
    }
}

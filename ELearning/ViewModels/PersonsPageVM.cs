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
    internal class PersonsPageVM : BaseVM
    {
        public PersonsPageVM() {
            DataService.personBLL.PersonsListChanged += OnPersonsListChanged;
            UpdateStudentsCollection();
        }
        
        private ObservableCollection<Person> students = new ObservableCollection<Person>( DataService.personBLL
            .PersonsList.Where((person) => person.RoleId == (int)UserRole.Student));
        public ObservableCollection<Person> Students
        {
            get => students;
            set
            {
                students = value;
                NotifyPropertyChanged("Students");
            }
        }

        private void OnPersonsListChanged(object sender, EventArgs e)
        {
            UpdateStudentsCollection();
        }

        private void UpdateStudentsCollection()
        {
            int size = students.Count;
            Students = new ObservableCollection<Person>(DataService.personBLL.PersonsList.Where((person) => person.RoleId == (int)UserRole.Student));

            if (size == students.Count)
            {
                Teachers = new ObservableCollection<Person>(DataService.personBLL.PersonsList.Where((person) => person.RoleId == (int)UserRole.Teacher));
            }
        }

        private ObservableCollection<Person> teachers = new ObservableCollection<Person>( DataService.personBLL
            .PersonsList.Where((person) => person.RoleId == (int)UserRole.Teacher));
        public ObservableCollection<Person> Teachers
        {
            get => teachers;
            set
            {
                teachers = value;
                NotifyPropertyChanged("Teachers");
            }
        }

        private ICommand addPersonCommand;
        public ICommand AddPersonCommand
        {
            get
            {
                if (addPersonCommand == null)
                {
                    addPersonCommand = new RelayCommand<Person>(DataService.personBLL.AddOrUpdatePerson);
                }
                return addPersonCommand;
            }
            set
            {
                addPersonCommand = value;
            }
        }
        
        private ICommand deletePersonCommand;
        public ICommand DeletePersonCommand
        {
            get
            {
                if (deletePersonCommand == null)
                {
                    deletePersonCommand = new RelayCommand<Person>(DataService.personBLL.DeletePerson);
                }
                return deletePersonCommand;
            }
            set
            {
                deletePersonCommand = value;
            }
        }
    }
}

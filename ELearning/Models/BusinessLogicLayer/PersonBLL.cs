using ELearning.Models.BusinessLogicLayer.Dtos;
using ELearning.Models.Data;
using ELearning.Models.Entities;
using ELearning.Models.Enums;
using ELearning.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfMVVMAgendaEF.Helpers;

namespace ELearning.Models.BusinessLogicLayer
{
    internal class PersonBLL : BaseVM
    {
        public ObservableCollection<Person> PersonsList { get; set; }
        private PersonRepository PersonRepository;
        public event EventHandler PersonsListChanged;

        public PersonBLL() {
            PersonRepository = new PersonRepository(DataService.context);
            PersonsList = new ObservableCollection<Person>(PersonRepository.GetAll());
        }

        public void AddOrUpdatePerson(Person person)
        {
            if (person == null)
            {
                MessageBox.Show("Please add required arguments!");
                return;
            }
            Person found = PersonsList.FirstOrDefault((pers) => pers.Email == person.Email);

            if (found != null)
            {
                person.Id = found.Id;
                found = person;
                PersonRepository.Update(person);
            }
            else
            {
                PersonRepository.Insert(person);
                PersonsList.Add(PersonRepository.FindByEmail(person.Email));
                if (person.RoleId == (int)UserRole.Teacher)
                {
                    TeachersBLL.AddTeacher(person);
                }
            }

            PersonsListChanged?.Invoke(this, EventArgs.Empty);
            NotifyPropertyChanged("PersonsList");
        }

        public void DeletePerson(Person person)
        {
            if (person == null)
            {
                MessageBox.Show("You didn't select any person!");
                return;
            }
            Person found = PersonsList.FirstOrDefault((pers) => pers.Email == person.Email);

            if (found != null)
            {
                if (person.RoleId == (int)UserRole.Teacher)
                {
                    TeachersBLL.DeleteTeacher(person);
                }
                PersonsList.Remove(found);
                PersonRepository.Remove(person);
                PersonsListChanged?.Invoke(this, EventArgs.Empty);
            }
            NotifyPropertyChanged("PersonsList");
        }

        public void Login(UserDto user) { 
        
            Person person = PersonRepository.FindByEmail(user.email);
            if (person != null)
            {
                if (person.password == user.password)
                {
                    UserRole userRole = (UserRole)Enum.Parse(typeof(UserRole), person.RoleId.ToString());

                    DataService.user = person;
                    DataService.CurrentWindow = new OptionsPage();
                    MessageBox.Show("You are logged in as " + userRole.ToString());
                    
                    //switch (userRole)
                    //{
                    //    case UserRole.Admin:
                    //        Console.WriteLine("User role is Admin");
                    //        break;
                    //    case UserRole.ClassMaster:
                    //        Console.WriteLine("User role is ClassMaster");
                    //        break;
                    //    case UserRole.Teacher:
                    //        Console.WriteLine("User role is Teacher");
                    //        break;
                    //    case UserRole.Student:
                    //        Console.WriteLine("User role is Student");
                    //        break;
                    //    default:
                    //        Console.WriteLine("Invalid user role");
                    //        break;
                    //}
                }
                else
                {
                    MessageBox.Show("Password is wrong, please try again!");
                }
            }
            else
            {
                MessageBox.Show("This email is not registered, please try again!");
            }
        }
    }
}

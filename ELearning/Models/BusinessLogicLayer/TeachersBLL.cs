using ELearning.Models.BusinessLogicLayer.Dtos;
using ELearning.Models.Data;
using ELearning.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaEF.Helpers;

namespace ELearning.Models.BusinessLogicLayer
{
    internal class TeachersBLL
    {
        public ObservableCollection<Teacher> TeachersList { get; set; }
        private static TeachersRepository teachersRepository = new TeachersRepository(DataService.context);

        public TeachersBLL()
        {
            GetAllTeachers();
        }

        private void GetAllTeachers()
        {
            TeachersList = new ObservableCollection<Teacher>(teachersRepository.GetAll());
        }

        public static void AddTeacher(Person person)
        {
            teachersRepository.Insert(new Teacher { Person = person, PersonId = person.Id});
        }
        
        public static void DeleteTeacher(Person person)
        {
            teachersRepository.Remove(teachersRepository.FindByPersonId(person.Id));
        }
    }
}

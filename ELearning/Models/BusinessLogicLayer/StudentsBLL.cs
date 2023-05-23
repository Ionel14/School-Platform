using ELearning.Models.BusinessLogicLayer.Dtos;
using ELearning.Models.Data;
using ELearning.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using WpfMVVMAgendaEF.Helpers;

namespace ELearning.Models.BusinessLogicLayer
{
    internal class StudentsBLL : BaseVM
    {
        public ObservableCollection<Student> StudentsList { get; set; }
        private StudentsRepository studentsRepository;
        ClassesBLL classesBLL;

        public StudentsBLL(ClassesBLL classesBLL)
        {
            this.classesBLL = classesBLL;
            studentsRepository = new StudentsRepository(DataService.context);
            StudentsList = new ObservableCollection<Student>(studentsRepository.GetAll());
        }

        public void AddStudent(StudentDto studentDto)
        {
            if (studentDto != null)
            {
                Student student = studentsRepository.FindByEmail(studentDto.Person.Email);
                if (student != null)
                {
                    if (student.Class == studentDto.Class)
                    {
                        MessageBox.Show("This student was already in the selected class");
                        return;
                    }

                    student.Class.Students.Remove(student);
                    student.Class = studentDto.Class;
                    student.ClassId = studentDto.Class.Id;
                    
                    if (student.Class.Students == null)
                    {
                        student.Class.Students = new List<Student>();
                    }
                    student.Class.Students.Add(student);

                    studentsRepository.Update(student);
                }
                else
                {
                    student = new Student();
                    student.Person = studentDto.Person;
                    student.PersonId = studentDto.Person.Id;

                    student.Class = studentDto.Class;
                    student.ClassId = studentDto.Class.Id;

                    if (student.Class.Students == null)
                    {
                        student.Class.Students = new List<Student>();
                    }
                    studentDto.Class.Students.Add(student);

                    studentsRepository.Insert(student);
                }
                classesBLL.Update(studentDto.Class);
                NotifyPropertyChanged("StudentsList");
            }
            else
            {
                MessageBox.Show("You didn't select a class or other required argument!\nPlease try again!");
            }
        }
        
        public void DeleteStudentFromClass(StudentDto studentDto)
        {
            if (studentDto != null)
            {
                Student student = studentsRepository.FindByEmail(studentDto.Person.Email);
                if (student != null)
                {
                    if (student.Class != studentDto.Class)
                    {
                        MessageBox.Show("This student is not in the selected class");
                        return;
                    }

                    student.Class.Students.Remove(student);
                    studentsRepository.Remove(student);
                    classesBLL.Update(studentDto.Class);
                    NotifyPropertyChanged("StudentsList");
                }
                else
                {
                    MessageBox.Show("This student is not in any class");
                }
            }
            else
            {
                MessageBox.Show("You didn't select a class or other required argument!\nPlease try again!");
            }
        }

    }
}

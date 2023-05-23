using ELearning.Models.Data;
using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELearning.Models.BusinessLogicLayer
{
    internal class CoursesBLL
    {
        public ObservableCollection<Course> CoursesList { get; set; }
        private CourseRepository CoursesRepository = new CourseRepository(DataService.context);

        public CoursesBLL()
        {
            CoursesList = new ObservableCollection<Course>(CoursesRepository.GetAll());
        }

        public void AddCourse(Course Course)
        {
            if (Course != null)
            {
                CoursesRepository.Insert(Course);
                CoursesList.Add(CoursesRepository.FindToGetId(Course));
            }
            else
            {
                MessageBox.Show("Please add required arguments!");
            }
        }

        public void DeleteCourse(Course Course)
        {
            if (Course == null)
            {
                MessageBox.Show("You didn't select any Course!");
                return;
            }

            CoursesList.Remove(Course);
            CoursesRepository.Remove(Course);
        }
    }
}

using ELearning.Models.BusinessLogicLayer;
using ELearning.Models.Entities;
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
    internal class CoursesManagementVM : BaseVM
    {
        private TeachersBLL teachersBLL = new TeachersBLL();
        private CoursesBLL coursesBLL = new CoursesBLL();
        private ClassesBLL classesBLL = new ClassesBLL();

        public ObservableCollection<Teacher> Teachers
        {
            get
            {
                return teachersBLL.TeachersList;
            }

            set
            {
                teachersBLL.TeachersList = value;
                NotifyPropertyChanged("Teachers");
            }
        }

        public ObservableCollection<Course> Courses
        {
            get
            {
                return coursesBLL.CoursesList;
            }

            set
            {
                coursesBLL.CoursesList = value;
                NotifyPropertyChanged("Courses");
            }
        }

        private ICommand addCourseCommand;
        public ICommand AddCourseCommand
        {
            get
            {
                if (addCourseCommand == null)
                {
                    addCourseCommand = new RelayCommand<Course>(coursesBLL.AddCourse);
                }
                return addCourseCommand;
            }
            set
            {
                addCourseCommand = value;
            }
        }

        private ICommand deleteCourseCommand;
        public ICommand DeleteCourseCommand
        {
            get
            {
                if (deleteCourseCommand == null)
                {
                    deleteCourseCommand = new RelayCommand<Course>(coursesBLL.DeleteCourse);
                }
                return deleteCourseCommand;
            }
            set
            {
                deleteCourseCommand = value;
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

        private ICommand addCourseToClassCommand;
        public ICommand AddCourseToClassCommand
        {
            get
            {
                if (addCourseToClassCommand == null)
                {
                    addCourseToClassCommand = new RelayCommand<Class>(classesBLL.Update);
                }
                return addCourseToClassCommand;
            }
            set
            {
                addCourseToClassCommand = value;
            }
        }

        private ICommand deleteCourseFromClassCommand;
        public ICommand DeleteCourseFromClassCommand
        {
            get
            {
                if (deleteCourseFromClassCommand == null)
                {
                    deleteCourseFromClassCommand = new RelayCommand<Class>(classesBLL.Update);
                }
                return deleteCourseFromClassCommand;
            }
            set
            {
                deleteCourseFromClassCommand = value;
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
    }
}

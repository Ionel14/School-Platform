using ELearning.Models.BusinessLogicLayer;
using ELearning.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ELearning.Converters
{
    internal class ClassAddCourseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!values.Any((val) => val == null))
            {
                Class myClass = values[0] as Class;
                Course course = values[1] as Course;

                Course found;
                if (myClass.Courses.IsNullOrEmpty())
                {
                    found = null;
                }
                else
                {
                    found = myClass.Courses.FirstOrDefault((c) => c.Name == course.Name);
                }

                //Update
                if (found != null)
                {
                    Thesis searchedThesis;
                    if (myClass.Theses.IsNullOrEmpty())
                    {
                        searchedThesis = null;
                    }
                    else
                    {
                        searchedThesis = myClass.Theses.FirstOrDefault((thesis) => thesis.Course == found);
                    }

                    if (searchedThesis != null)
                    {
                        myClass.Theses.Remove(searchedThesis);
                        ThesesBLL thesesBLL = new ThesesBLL();
                        thesesBLL.DeleteClassFromThesis(searchedThesis.Course, myClass);
                        return myClass;
                    }
                }
                //Add
                else
                {
                    if (myClass.Courses.IsNullOrEmpty())
                    {
                        myClass.Courses = new List<Course>();
                    }
                    myClass.Courses.Add(course);
                }

                //Add Thesis
                if ((bool)values[2])
                {
                    Thesis thesis = new Thesis
                    {
                        CourseId = course.Id,
                        Course = course,
                        Classes = new List<Class> { myClass },
                    };
                    ThesesBLL thesesBLL = new ThesesBLL();
                    thesesBLL.AddThesis(thesis);

                    if (myClass.Theses.IsNullOrEmpty())
                    {
                        myClass.Theses = new List<Thesis>();
                    }
                    myClass.Theses.Add(thesesBLL.FindByCourse(thesis.Course));
                }

                return myClass;
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Class @class = value as Class;
            object[] result = { @class.Name, @class.Specialization, @class.SpecializationId };
            return result;
        }
    }
}

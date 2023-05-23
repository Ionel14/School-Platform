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
    internal class ClassDeleteCourseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!values.Any((val) => val == null))
            {
                Class myClass = values[0] as Class;
                Course course = values[1] as Course;

                ThesesBLL thesesBLL = new ThesesBLL();
                thesesBLL.DeleteClassFromThesis(course, myClass);
                myClass.Courses.Remove(course);
                course.Classes.Remove(myClass);

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

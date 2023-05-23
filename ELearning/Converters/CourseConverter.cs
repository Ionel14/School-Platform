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
    internal class CourseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!values[0].ToString().IsNullOrEmpty() && values[1] != null && values[1] != DependencyProperty.UnsetValue)
            {
                return new Course()
                {
                    Name = values[0].ToString(),
                    Teacher = values[1] as Teacher,
                    TeacherId = (values[1] as Teacher).Id,
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Course @Course = value as Course;
            object[] result = { @Course.Name, @Course.Teacher, @Course.TeacherId };
            return result;
        }
    }
}

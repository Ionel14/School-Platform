using ELearning.Models.BusinessLogicLayer.Dtos;
using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ELearning.Converters
{
    internal class StudentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.All((val) => val != null && val != DependencyProperty.UnsetValue))
            {
                return new StudentDto()
                {
                    Person = values[0] as Person,
                    Class = values[1] as Class,
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

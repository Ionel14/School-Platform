using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ELearning.Converters
{
    internal class ClassConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {
                return new Class()
                {
                    Name = values[0].ToString(),
                    Specialization = values[1] as Specialization,
                    SpecializationId = (values[1] as Specialization).Id,
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Class @class = value as Class;
            object[] result = { @class.Name, @class.Specialization, @class.SpecializationId};
            return result;
        }
    }
}

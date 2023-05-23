using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ELearning.Converters
{
    internal class ClassMasterConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {
                return new ClassMaster()
                {
                    Class = values[0] as Class,
                    ClassId = (values[0] as Class).Id,
                    Teacher = values[1] as Teacher,
                    TeacherId = (values[1] as Teacher).Id,
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            ClassMaster @class = value as ClassMaster;
            object[] result = { @class.ClassId, @class.TeacherId};
            return result;
        }
    }
}

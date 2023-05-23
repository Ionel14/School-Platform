using ELearning.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ELearning.Converters
{
    internal class ClassThesesToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.Any((val) => val == null))
            {
                List<Thesis> theses = values[0] as List<Thesis>;
                string courseName = values[1].ToString();

                if (theses.IsNullOrEmpty())
                {
                    //return new SolidColorBrush(Colors.Red);
                    return "No";
                }

                if (theses.Any((thesis) => thesis.Course.Name == courseName))
                {
                    return "Yes";
                }

                return "No";
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

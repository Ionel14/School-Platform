using ELearning.Models.BusinessLogicLayer.Dtos;
using ELearning.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ELearning.Converters
{
    internal class PersonDtoConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!values[1].ToString().IsNullOrEmpty() && !values[2].ToString().IsNullOrEmpty() && !values[3].ToString().IsNullOrEmpty() 
                && !values[4].ToString().IsNullOrEmpty() && !values[5].ToString().IsNullOrEmpty())
            {
                int RoleId;
                if (values[0].ToString() == "Students")
                {
                    RoleId = 4;
                }
                else
                {
                    RoleId = 3;
                }
                
                return new Person()
                {
                    RoleId = RoleId,
                    FirstName = values[1].ToString(),
                    LastName = values[2].ToString(),
                    Email = values[3].ToString(),
                    password = values[4].ToString(),
                    DateOfBirth = DateTime.Parse(values[5].ToString()),
                    Address = values[6].ToString(),
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Person person = value as Person;
            object[] result = { person.RoleId, person.FirstName, person.LastName, person.Email, person.password, person.DateOfBirth, person.Address };
            return result;
        }
    }
}

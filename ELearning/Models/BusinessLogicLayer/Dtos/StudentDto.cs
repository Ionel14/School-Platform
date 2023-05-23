using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.BusinessLogicLayer.Dtos
{
    internal class StudentDto
    {
        public Person Person { get; set; }
        public Class Class { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Entities
{
    internal class Student : BaseEntity
    {
        [Required]
        public int ClassId { get; set; }
        public Class Class { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public List<Grade> Grades { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Entities
{
    internal class Teacher : BaseEntity
    {
        public List<Course> Courses { get; set; }
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}

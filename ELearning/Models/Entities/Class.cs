using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Entities
{
    internal class Class : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Thesis> Theses { get; set; }

    }
}

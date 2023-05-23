using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Entities
{
    internal class Absence : BaseEntity
    {
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        public int Semester { get; set; }

        public bool Motivated { get; set; }
    }
}

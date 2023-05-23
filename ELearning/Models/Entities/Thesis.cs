using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Entities
{
    internal class Thesis : BaseEntity
    {
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set;}

        [Required]
        public List<Class> Classes { get; set;}
        
        public List<GradeThesis> GradeTheses { get; set;}

    }
}

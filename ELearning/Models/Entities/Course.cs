using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Entities
{
    internal class Course : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<Class> Classes{ get; set; }
    }
}

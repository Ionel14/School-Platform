using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Entities
{
    internal class ClassMaster: BaseEntity
    {
        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required]
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}

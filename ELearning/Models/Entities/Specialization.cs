using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Entities
{
    internal class Specialization : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}

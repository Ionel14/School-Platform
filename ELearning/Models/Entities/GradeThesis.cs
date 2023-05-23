using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Entities
{
    internal class GradeThesis
    {
        [Key, Column(Order = 0)]
        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        [Key, Column(Order = 1)]
        public int ThesisId { get; set; }
        public Thesis Thesis { get; set; }
    }
}

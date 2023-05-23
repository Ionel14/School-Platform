using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Data
{
    internal class GradeRepository : RepositoryBase<Grade>
    {
        private readonly SchoolDbContext dbContext;

        public GradeRepository(SchoolDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

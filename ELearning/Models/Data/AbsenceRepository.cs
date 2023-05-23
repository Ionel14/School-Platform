using ELearning.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Models.Data
{
    internal class AbsenceRepository : RepositoryBase<Absence>
    {
        private readonly SchoolDbContext dbContext;

        public AbsenceRepository(SchoolDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
